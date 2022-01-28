using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public interface IThingDeserializer
    {
        /// <summary>
        /// Deserializes the given xml.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>An object of type <see cref="Thing"/>.</returns>
        Thing Deserialize(string xml);
    }
}
