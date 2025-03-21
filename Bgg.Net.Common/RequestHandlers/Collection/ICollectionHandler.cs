﻿using Bgg.Net.Common.Infrastructure;
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
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserName(string userName);

        /// <summary>
        /// Gets a brief collection by the users name. 
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetBriefCollectionByUserName(string userName);

        /// <summary>
        /// Gets only the played items in a collection by the users name.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetPlayedCollectionByUserName(string userName);

        /// <summary>
        /// Gets the wishlisted items in a collection by the users name.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetWishListCollectionByUserName(string userName);

        /// <summary>
        /// Gets the stats of the collection by the users name.
        /// </summary>
        /// <param name="userName">>The users collection to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetCollectionStatsByUserName(string userName);

        /// <summary>
        /// Gets a collection by the users name and items type.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <param name="subtype">The type of the item.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserNameAndSubtype(string userName, CollectionSubType subtype);

        /// <summary>
        /// Gets a collection by the users name and item ids.
        /// </summary>
        /// <param name="userName">The users collection to retrieve.</param>
        /// <param name="ids">The ids of items to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserNameAndId(string userName, List<long> ids);

        /// <summary>
        /// Gets a collection by the parameters provided in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="Models.Bgg.Collection"/>.</returns>
        Task<BggResult<Models.Bgg.Collection>> GetCollection(CollectionRequest request);
    }
}
