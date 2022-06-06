using Bgg.Net.Common.Infrastructure.Exceptions;
using Bgg.Net.Common.Models;
using Serilog;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public class BggDeserializer : IBggDeserializer
    {
        private readonly ILogger _logger;

        public BggDeserializer(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public T Deserialize<T>(string xml)
            where T : BggBase
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            try
            {
                using var stringReader = new StringReader(xml);

                var serializer = new XmlSerializer(typeof(T));
                var xmlReader = new XmlTextReader(stringReader);


                return (T)serializer.Deserialize(xmlReader);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error during deserialization.");
                throw new XmlDeserializationException(e.Message, e.InnerException);
            }
        }
    }
}
