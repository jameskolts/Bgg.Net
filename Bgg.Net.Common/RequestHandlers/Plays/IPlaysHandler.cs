using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Plays
{
    /// <summary>
    /// Public interface for Plays queries.
    /// </summary>
    public interface IPlaysHandler
    {
        /// <summary>
        /// Gets the plays by the given user name.
        /// </summary>
        /// <param name="userName">The userName to retrieve plays for.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserName(string userName);

        /// <summary>
        /// Gets the plays of a specific item and user.
        /// </summary>
        /// <param name="userName">The userName to retrieve plays for.</param>
        /// <param name="id">The Id of the item to retrieve plays for.></param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserNameAndId(string userName, long id);

        /// <summary>
        /// Gets the plays of a specific Type of item for a user.
        /// </summary>
        /// <param name="userName">The userName to retrieve plays for.</param>
        /// <param name="type">The type of items to retrieve.</param>
        /// <param name="subType">Optional parameter of subtype to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserNameAndType(string userName, ItemType type, ItemSubType? subType = null);

        /// <summary>
        /// Gets the plays within a specific time period for a user.
        /// </summary>
        /// <param name="userName">The user to retrieve plays for.</param>
        /// <param name="start">The start date, inclusive.</param>
        /// <param name="end">The end date, inclusive.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserNameAndDate(string userName, DateOnly start, DateOnly end);

        /// <summary>
        /// Gets the plays given extensible parameters.
        /// </summary>
        /// <param name="extension">The parameters to use.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>Supported parameters include: 'username', 'id', 'type', mindate', 'maxdate', 'subtype', 'page'.</remarks>
        Task<BggResult<PlayList>> GetPlaysExtensible(Extension extension);
    }
}
