using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Plays
{
    /// <summary>
    /// Public interface for Plays queries.
    /// </summary>
    public interface IPlaysHandler
    {
        /// <summary>
        /// Gets the plays by the given query.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlays(PlaysRequest request);

        /// <summary>
        /// Gets the plays by the given user name.
        /// </summary>
        /// <param name="userName">The userName to retrieve plays for.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserName(string userName);

        /// <summary>
        /// Gets the plays of a specific Type of item for a user.
        /// </summary>
        /// <param name="userName">The userName to retrieve plays for.</param>
        /// <param name="type">The type of items to retrieve.</param>
        /// <param name="subType">Optional parameter of subtype to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserNameAndType(string userName, ItemType type, PlaysSubType? subType = null);

        /// <summary>
        /// Gets the plays within a specific time period for a user.
        /// </summary>
        /// <param name="userName">The user to retrieve plays for.</param>
        /// <param name="start">The start date, inclusive.</param>
        /// <param name="end">The end date, inclusive.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</returns>
        Task<BggResult<PlayList>> GetPlaysByUserNameAndDate(string userName, DateOnly start, DateOnly end);

        /// <summary>
        /// Gets the plays for a specific id and type.
        /// </summary>
        /// <param name="id">The id of the item.</param>
        /// <param name="type">A <see cref="BggResult{T}"/> where T is a <see cref="Guild"/>.</param>
        /// <returns></returns>
        Task<BggResult<PlayList>> GetPlaysByIdAndType(long id, ItemType type);
    }
}
