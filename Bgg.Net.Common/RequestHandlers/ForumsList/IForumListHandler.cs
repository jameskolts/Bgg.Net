using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.ForumsList
{
    /// <summary>
    /// Public interface that handles ForumList requests to the Bgg XmlApi2.
    /// </summary>
    public interface IForumListHandler
    {
        /// <summary>
        /// Gets a ForumList by the given id and type.
        /// </summary>
        /// <param name="id">The id of the forumlist to retrieve.</param>
        /// <param name="type">The type of the forumlist to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="ForumList"/>.</returns>
        Task<BggResult<ForumList>> GetForumListByIdAndType(long id, ItemType type);
    }
}
