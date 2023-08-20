using Bgg.Net.Common.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Infrastructure.Deserialization
{
    public class XmlDeserializer : IDeserializer
    {
        private readonly ILogger<XmlDeserializer> _logger;

        public XmlDeserializer(ILogger<XmlDeserializer> logger)
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
                using var stringReader = new StringReader(textContent);

                var serializer = new XmlSerializer(typeof(T));
                var xmlReader = new XmlTextReader(stringReader);

                return (T)serializer.Deserialize(xmlReader);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during deserialization.");
                throw new XmlDeserializationException(e.Message, e.InnerException);
            }
        }
    }
}
