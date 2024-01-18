using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers
{
    /// <summary>
    /// Base Request Handler class.
    /// </summary>
    public abstract class RequestHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
    {
        protected readonly IDeserializerFactory _deserializerFactory = deserializerFactory;
        protected readonly ILogger<RequestHandler> _logger = logger;
        protected readonly IHttpClient _httpClient = httpClient;
        protected readonly IRequestValidatorFactory _requestValidatorFactory = validatorFactory;
        protected readonly IQueryBuilder _queryBuilder = queryBuilder;

        /// <summary>
        /// Constructs a BggResult of the given type.  
        /// Will deserialize the httpResponse objects content to populate the result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="httpResponse">The <see cref="HttpResponseMessage"/> to deserialize.</param>
        /// <returns>The <see cref="BggResult{T}"/> populated from the httpResponse.</returns>
        protected async Task<BggResult<T>> BuildBggResult<T>(HttpResponseMessage httpResponse)
            where T : class
        {
            var bggResult = new BggResult<T>();

            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                bggResult.Item = _deserializerFactory.Create(typeof(T))
                    .Deserialize<T>(responseString);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred during deserialization. {message} {stacktrace}", e.Message, e.StackTrace);
                bggResult.Errors.Add($"An error occurred during deserialization. {e.Message} {e.StackTrace}");
            }

            bggResult.IsSuccessful = httpResponse.IsSuccessStatusCode && !bggResult.Errors.Any();
            bggResult.HttpResponseCode = httpResponse.StatusCode;

            return bggResult;
        }

        /// <summary>
        /// Gets a resource from the BGG XML API2 using a request to build the query.
        /// </summary>
        /// <typeparam name="T">The typeof the resource.</typeparam>
        /// <param name="resourceName">The resource name to use in the query.</param>
        /// <param name="request">The request to use to build the query.</param>
        /// <returns>A <see cref="BggResult{T}"/> of the given type.</returns>
        protected async Task<BggResult<T>> GetResourceFromRequestObject<T>(string resourceName, BggRequest request)
            where T : BggBase
        {
            _logger.LogInformation("Get {resource}: {request}", resourceName.UpperFirstChar(), request);

            var validator = _requestValidatorFactory.CreateRequestValidator(resourceName);
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return new BggResult<T>
                {
                    IsSuccessful = false,
                    Errors = validationResult.Errors
                };
            }

            var query = _queryBuilder.BuildQuery(resourceName, request);
            _logger.LogInformation("Performing query: {query}", query);

            var httpResponseMessage = await _httpClient.GetAsync(query);

            return await BuildBggResult<T>(httpResponseMessage);
        }
    }
}