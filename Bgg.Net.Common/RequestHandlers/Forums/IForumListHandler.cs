using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Forums
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

        /// <summary>
        /// Gets a ForumList by the given query.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="ForumList"/>.</returns>
        Task<BggResult<ForumList>> GetForumList(ForumListRequest request);
    }
}
