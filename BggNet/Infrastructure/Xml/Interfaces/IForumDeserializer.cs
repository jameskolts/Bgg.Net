using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml.Interfaces
{    
    public interface IForumDeserializer
    {
        /// <summary>
        /// Deserializes the given xml into a list of forum
        /// </summary>
        /// <param name="xml">The xml to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Forum"/>.</returns>
        List<Forum> Deserialize(string xml);


        /// <summary>
        /// Deserializes the given xml into a single forum.
        /// </summary>
        /// <param name="xml">The xml to deserialize.</param>
        /// <returns>a <see cref="Forum"/>.</returns>
        Forum DeserializeForum(string xml);
    }
}
