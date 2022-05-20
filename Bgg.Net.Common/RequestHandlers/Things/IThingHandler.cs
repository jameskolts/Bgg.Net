using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.RequestHandlers.Things
{
    /// <summary>
    /// Public interface that handles Thing queries.
    /// </summary>
    public interface IThingHandler
    {
        /// <summary>
        /// Gets a thing by the given id.
        /// </summary>
        /// <param name="id">The id of the thing to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<ThingList>> GetThingById(int id);

        /// <summary>
        /// Gets multiple things by the given ids.
        /// </summary>
        /// <param name="ids">the id's of the things to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<ThingList>> GetThingsById(List<int> ids);

        /// <summary>
        /// Gets a thing given extensible parameters. 
        /// </summary>
        /// <param name="extensions">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>Supported parameters include: 'id', 'type', 'versions', videos', 'stats', 'marketplace', 'comments',
        /// 'ratings', 'page', 'pagesize'.</remarks>
        Task<BggResult<ThingList>> GetThingsExtensible(Extension extensions);
    }
}
