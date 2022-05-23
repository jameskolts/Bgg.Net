using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Guilds
{
    /// <summary>
    /// Public interface for guild queries.
    /// </summary>
    public interface IGuildHandler
    {
        /// <summary>
        /// Gets a guild by the given id.
        /// </summary>
        /// <param name="id">The id to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<Guild>> GetGuildById(long id);

        /// <summary>
        /// Gets a guild by the given id.  Includes members in the result.
        /// </summary>
        /// <param name="id">The id to retrieve.</param>
        /// <param name="sortType">Optional parameter dictate how to sort the members.  Defaults to username.</param>
        /// <param name="page">Optional parameter indicates which page of members to include in the set.  Defaults to 1.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<Guild>> GetGuildByIdWithMembers(long id, SortType sortType = SortType.UserName, int page = 1);

        /// <summary>
        /// Gets a guild given extensible parameters.
        /// </summary>
        /// <param name="extension">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>Supported parameters include: 'id', 'members', 'sort', page'.</remarks>
        Task<BggResult<Guild>> GetGuildExtensible(Extension extension);
    }
}
