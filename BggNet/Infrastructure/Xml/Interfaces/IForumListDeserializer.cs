using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Infrastructure.Xml.Interfaces
{
    public interface IForumListDeserializer
    {
        /// <summary>
        /// Deserializes the given xml into a list of forumlist.
        /// </summary>
        /// <param name="xml">Thing string to deserialize.</param>
        /// <returns>An <see cref="List{T}"/> of <see cref="ForumList"/>.</returns>
        ForumList Deserialize(string xml);
    }
}
