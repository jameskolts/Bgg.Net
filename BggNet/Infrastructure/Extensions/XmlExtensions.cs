using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for Xml.
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Deserializes an object from a string of Xml.
        /// </summary>
        /// <typeparam name="T">The object to deserialize to.</typeparam>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>An object of the specified type.</returns>
        public static T FromXml<T>(this string value)
        {
            using TextReader reader = new StringReader(value);
            return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
        }

        public static XElement ToXmlElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }

        public static XmlNode ToXmlNode(this XElement element)
        {
            using XmlReader xmlReader = element.CreateReader();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlReader);
            return xmlDoc.FirstChild;
        }
    }
}
