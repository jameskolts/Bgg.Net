﻿using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;

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
        Task<BggResult<Forum>> GetForumByIdAndPage(long id, uint page);

        /// <summary>
        /// Gets a fourm by the given query.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Forum"/>.</returns>
        Task<BggResult<Forum>> GetForum(ForumRequest request);
    }
}
