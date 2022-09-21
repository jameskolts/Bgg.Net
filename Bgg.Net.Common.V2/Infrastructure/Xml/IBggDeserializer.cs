using Bgg.Net.Common.Infrastructure.Exceptions;
using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    /// <summary>
    /// Public interface for the BoardGameGeek Deserializer.
    /// </summary>
    public interface IBggDeserializer
    {
        /// <summary>
        /// Deserializes the given xml to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.  Must be derived from <see cref="BggBase"/>.</typeparam>
        /// <param name="xml">A stringified version of an xml document.</param>
        /// <returns>An object of the given type.</returns>
        /// <exception cref="XmlDeserializationException">Thrown if there's any issue with deserialization.</exception>
        T Deserialize<T>(string xml)
            where T : BggBase;
    }
}
