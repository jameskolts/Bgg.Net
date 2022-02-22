using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers
{
    //TODO: Make this into a base class that works for all handlers.  Deserialization is the tricky part.
    public abstract class RequestHandler
    {
        protected readonly IBggDeserializer _bggDeserializer;
        protected readonly ILogger _logger;

        /// <summary>
        /// Injects an instance of deserializer and logger into the RequestHandler. 
        /// </summary>
        /// <param name="deserializer"></param>
        /// <param name="logger"></param>
        public RequestHandler(IBggDeserializer deserializer, ILogger logger)
        {
            _bggDeserializer = deserializer;
            _logger = logger;
        }

        protected async Task<BggResult<T>> BuildBggResult<T>(HttpResponseMessage httpResponse)
            where T : BggBase
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var bggResult = new BggResult<T>();

            try
            {
                bggResult.Items = _bggDeserializer.DeserializeList<T>(responseString); 
            }
            catch (Exception exception)
            {
                var errorString = $"Error during deserialization. {exception.Message}";
                _logger.Error(exception, errorString);
                bggResult.Errors.Add(errorString);
            }

            bggResult.IsSuccessful = httpResponse.IsSuccessStatusCode && !bggResult.Errors.Any();
            bggResult.HttpResponseCode = httpResponse.StatusCode;

            return bggResult;
        }
    }
}
