using Bgg.Net.Common.Models;
using Bgg.Net.Common.Infrastructure;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    public interface IForumHandler
    {
        /// <summary>
        /// Gets a Forum by the given id.
        /// </summary>
        /// <param name="id">The id of the forum to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Forum"/>.</returns>
        Task<BggResult<Forum>> GetForumById(long id);

        /// <summary>
        /// Gets a forum by the given id with a specific page of threads to return.
        /// </summary>        /// 
        /// <param name="id">The id of the forum to retrieve.</param>
        /// <param name="page">The page of threads to include in the Thread list.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Forum"/>.</returns>
        /// <remarks>Page size is 50.  Threads are sorted in order of the most recent post.</remarks>
        Task<BggResult<Forum>> GetForumByIdAndPage(long id, int page);
    }
}
