using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.RequestHandlers.Things
{
    /// <summary>
    /// Public interface that handles Thing queries.
    /// </summary>
    public interface IThingHandler
    {
        /// <summary>
        /// Gets a thing by the parameters in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<ThingList>> GetThing(ThingRequest request);

        /// <summary>
        /// Gets a thing by the given id.
        /// </summary>
        /// <param name="id">The id of the thing to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<ThingList>> GetThingById(long id);

        /// <summary>
        /// Gets multiple things by the given ids.
        /// </summary>
        /// <param name="ids">the id's of the things to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<ThingList>> GetThingsById(List<long> ids);
    }
}
