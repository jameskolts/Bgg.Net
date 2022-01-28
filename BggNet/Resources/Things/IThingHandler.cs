using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Resources.Things
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
        Task<BggResult<Thing>> GetThingById(int id);

        /// <summary>
        /// Searches for a thing by name.
        /// </summary>
        /// <param name="name">The name to search by.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<Thing>> SearchByName(string name);

        /// <summary>
        /// Gets a thing given extensible parameters. 
        /// </summary>
        /// <param name="extensions">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Thing"/>.</returns>
        Task<BggResult<Thing>> GetThingsExtensible(Extension extensions);
    }
}
