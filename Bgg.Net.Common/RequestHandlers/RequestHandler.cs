using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers
{
    /// <summary>
    /// Base Request Handler class.
    /// </summary>
    public abstract class RequestHandler
    {
        protected readonly IBggDeserializer _bggDeserializer;
        protected readonly ILogger _logger;
        protected readonly IHttpClient _httpClient;
        protected readonly IRequestValidatorFactory _requestValidatorFactory;
        protected readonly IQueryBuilder _queryBuilder;

        public RequestHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
        {
            _bggDeserializer = deserializer;
            _logger = logger;
            _httpClient = httpClient;
            _requestValidatorFactory = validatorFactory;
            _queryBuilder = queryBuilder;
        }

        /// <summary>
        /// Constructs a BggResult of the given type.  
        /// Will deserialize the httpResponse objects content to populate the result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="httpResponse">The <see cref="HttpResponseMessage"/> to deserialize.</param>
        /// <returns>The <see cref="BggResult{T}"/> populated from the httpResponse.</returns>
        protected async Task<BggResult<T>> BuildBggResult<T>(HttpResponseMessage httpResponse)
            where T : BggBase
        {
            var bggResult = new BggResult<T>();

            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                bggResult.Item = _bggDeserializer.Deserialize<T>(responseString);
            }
            catch (Exception exception)
            {
                var errorString = $"Error during deserialization. {exception.Message}";
                bggResult.Errors.Add(errorString);
                _logger.Error(exception, errorString);
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
            _logger.Information("Get" + resourceName.UpperFirstChar() + " : {request}", request);

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
            _logger.Information("Performing query: " + query);

            var httpResponseMessage = await _httpClient.GetAsync(query);

            return await BuildBggResult<T>(httpResponseMessage);
        }
    }
}