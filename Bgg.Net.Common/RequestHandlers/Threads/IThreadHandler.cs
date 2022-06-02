using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Common.RequestHandlers.Threads
{
    /// <summary>
    /// Public interface that handles Thread requests to the BGG XmlApi2.
    /// </summary>
    public interface IThreadHandler
    {
        /// <summary>
        /// Gets a thread by the given id.
        /// </summary>
        /// <param name="id">The id to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Thread"/>.</returns>
        Task<BggResult<Thread>> GetThreadById(int id);

        /// <summary>
        /// Gets a thread by the parameters provided in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="Thread"/>.</returns>
        Task<BggResult<Thread>> GetThread(ThreadRequest request);
    }
}
