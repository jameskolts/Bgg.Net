using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
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

        /// <summary>
        /// Creates a new instance of <see cref="RequestHandler"/>.
        /// </summary>
        /// <param name="deserializer">The <see cref="IBggDeserializer"/> that will deserialize the response.</param>
        /// <param name="logger">The <see cref="ILogger"/> instance.</param>
        /// <param name="httpClient">The <see cref="IHttpClient"/> that will handle http requests.</param>
        public RequestHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient)
        {
            _bggDeserializer = deserializer;
            _logger = logger;
            _httpClient = httpClient;
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
        /// Gets a resource from the BGG API2 extensibly. 
        /// </summary>
        /// <typeparam name="T">The type of the resource.</typeparam>
        /// <param name="resourceName">The resource name to use in the query.</param>
        /// <param name="supportedParameters">The supported parameters for this resource.</param>
        /// <param name="queryParameters">The query parameters to execute.</param>
        /// <returns>A <see cref="BggResult{T}"/> of the given type.</returns>
        protected async Task<BggResult<T>> GetResourceExtensible<T>(string resourceName, IEnumerable<string> supportedParameters, Extension queryParameters)
            where T : BggBase
        {
            _logger.Information("Get" + resourceName.UpperFirstChar() +"Extensible : {queryParameters}", queryParameters.ToString());

            foreach (var kvp in queryParameters.Value)
            {
                if (!supportedParameters.Contains(kvp.Key))
                {
                    string errorMessage = $"'{kvp.Key}' parameter is not supported for Get{resourceName.UpperFirstChar()}Extensible.";
                    _logger.Error(errorMessage);

                    return new BggResult<T>
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { errorMessage }
                    };
                }
            }

            string queryString = $"{resourceName}?" + string.Join("&", queryParameters.Value.Select(x => x.Key + "=" + string.Join(',', x.Value)));
            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<T>(httpResponseMessage);
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


            var type = request.GetType();
            var propInfo = type.GetProperties();
            var query = $"{resourceName}?" + propInfo.First().Name.ToLower() + request.GetType().GetProperty(propInfo.First().Name);

            foreach (var prop in propInfo.Skip(1))
            {
                var pi = type.GetProperty(prop.Name);

                if (pi.GetValue(request) != null)
                {
                    query += "&";
                    query += prop.Name.ToLower();
                    query += "=";
                    query += request.GetType().GetProperty(prop.Name).GetValue(request, null);
                }
            }

            var httpResponseMessage = await _httpClient.GetAsync(query);

            return await BuildBggResult<T>(httpResponseMessage);
        }        
    }
}

