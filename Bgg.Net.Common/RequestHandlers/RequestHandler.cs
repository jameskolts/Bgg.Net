using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

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
        /// Gets a resource from the given Url using POST.
        /// Will deserialize the httpRespone objects content to populate the result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="url">The url to send the request to.</param>
        /// <param name="stringContent">The content to post to the url.</param>
        /// <returns>The <see cref="BggResult{T}"/> populated from the httpResponse</returns>
        protected async Task<BggResult<T>> PostRequest<T>(string url, StringContent stringContent)
            where T : class
        {
            var result = new BggResult<T>();
            var httpResponse = await _httpClient.PostAsync(url, stringContent);

            //TODO: think about refactoring this so that BuildBggResult can work for both json and xml apis
            try
            {
                result.Item = JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred during deserialization. {message} {stacktrace}", e.Message, e.StackTrace);
                result.Errors.Add($"An error occurred during deserialization. {e.Message} {e.StackTrace}");
            }

            result.IsSuccessful = httpResponse.IsSuccessStatusCode && !result.Errors.Any();
            result.HttpResponseCode = httpResponse.StatusCode;

            return result;
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