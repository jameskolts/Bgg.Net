using Bgg.Net.Common.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Bgg.Net.Common.Infrastructure.Deserialization
{
    public class JsonDeserializer : IDeserializer
    {
        private readonly ILogger<JsonDeserializer> _logger;

        public JsonDeserializer(ILogger<JsonDeserializer> logger)
        {
            _logger = logger;
        }

        public T Deserialize<T>(string textContent)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(textContent))
            {
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(textContent);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during deserialization");
                throw new JsonDeserializationException(e.Message, e.InnerException);
            }
        }
    }
}
