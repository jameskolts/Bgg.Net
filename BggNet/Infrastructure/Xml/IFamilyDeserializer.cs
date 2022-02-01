using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml
{
    public interface IFamilyDeserializer
    {
        /// <summary>
        /// Deserializes the given xml into a list of Families.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="Family"/>.</returns>
        List<Family> Deserialize(string xml);
    }
}
