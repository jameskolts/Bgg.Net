using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml.Interfaces
{
    public interface IThingDeserializer
    {
        /// <summary>
        /// Deserializes the given xml into a list of Things.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Thing"/>.</returns>
        List<Thing> Deserialize(string xml);
    }
}
