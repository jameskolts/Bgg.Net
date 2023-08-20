using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Collection
{
    /// <summary>
    /// Handles Collection requests to the Bgg API.
    /// </summary>
    public class CollectionHandler : RequestHandler, ICollectionHandler
    {
        public CollectionHandler(IDeserializerFactory deserializerFactory, ILogger logger, ICollectionClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetBriefCollectionByUserName(string userName)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                Brief = true
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetCollection(CollectionRequest request)
        {
            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserName(string userName)
        {
            var request = new CollectionRequest(userName);

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserNameAndId(string userName, List<long> ids)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                Id = ids
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetCollectionByUserNameAndSubtype(string userName, CollectionSubType subtype)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                Subtype = subtype.ToString()
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetCollectionStatsByUserName(string userName)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                Stats = true
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetPlayedCollectionByUserName(string userName)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                Played = true
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Bgg.Collection>> GetWishListCollectionByUserName(string userName)
        {
            var request = new CollectionRequest
            {
                UserName = userName,
                WishList = true
            };

            return await GetResourceFromRequestObject<Models.Bgg.Collection>("collection", request);
        }
    }
}
