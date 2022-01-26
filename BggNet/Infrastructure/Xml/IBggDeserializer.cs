using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public interface IBggDeserializer
    {
        /// <summary>
        /// Deserializes the given xml.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>An object of type BggBase.</returns>
        BggBase Deserialize(string xml);
    }
}
