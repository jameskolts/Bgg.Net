using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Collection
{
    /// <summary>
    /// Public interface for collection queries.
    /// </summary>
    public interface ICollectionHandler
    {
        /// <summary>
        /// Gets a collection by the users name.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetCollectionByUserName(string userName);

        /// <summary>
        /// Gets a brief collection by the users name. 
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetBriefCollectionByUserName(string userName);

        /// <summary>
        /// Gets only the played items in a collection by the users name.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetPlayedCollectionByUserName(string userName);

        /// <summary>
        /// Gets the wishlisted items in a collection by the users name.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetWishListCollectionByUserName(string userName);

        /// <summary>
        /// Gets the stats of the collection by the users name.
        /// </summary>
        /// <param name="userName">>The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetCollectionStatsByUserName(string userName);

        /// <summary>
        /// Gets a collection by the users name and items type.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <param name="type">The type of the item.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetCollectionByUserNameAndType(string userName, CollectionSubType type);

        /// <summary>
        /// Gets a collection by the users name and item ids.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <param name="ids">The ids of items to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetCollectionByUserNameAndId(string userName, List<long> ids);

        /// <summary>
        /// Gets a collection by the parameters provided in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        Task<BggResult<Models.Collection>> GetCollection(CollectionRequest request);

        /// <summary>
        /// Gets a collection given extensible parameters.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Collection"/>.</returns>
        /// <exception cref="NotSupportedException">Thrown if the extension is an unsupported parameter.</exception>
        /// <remarks>See <see cref="Constants.SupportedCollectionParameters"/>.</remarks>
        Task<BggResult<Models.Collection>> GetCollectionExtensible(Extension extension);
    }
}
