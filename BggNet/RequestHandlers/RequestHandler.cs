using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
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
        /// <param name="httpResponse">The <see cref="HttpResponseMessage"/ to deserialize.></param>
        /// <returnsThe <see cref="BggResult{T}"/> populated from the httpResponse.</returns>
        protected async Task<BggResult<T>> BuildBggResult<T>(HttpResponseMessage httpResponse)
            where T : BggBase
        {            
            var bggResult = new BggResult<T>();

            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                bggResult.Items.Add(_bggDeserializer.Deserialize<T>(responseString));
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
    }
}

