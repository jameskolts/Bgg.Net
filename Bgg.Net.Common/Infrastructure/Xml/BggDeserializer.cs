using Bgg.Net.Common.Infrastructure.Exceptions;
using Bgg.Net.Common.Models;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public class BggDeserializer : IBggDeserializer
    {
        /// <inheritdoc/>
        public T Deserialize<T>(string xml) 
            where T : BggBase
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return null;
            }

            using var stringReader = new StringReader(xml);

            var serializer = new XmlSerializer(typeof(T));
            var xmlReader = new XmlTextReader(stringReader);

            try
            {
                return (T)serializer.Deserialize(xmlReader);
            }
            catch (Exception e)
            {
                throw new XmlDeserializationException(e.Message, e.InnerException);
            }
        }
    }
}
