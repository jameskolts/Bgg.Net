using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Collection
{
    /// <summary>
    /// Handles Collection requests to the Bgg API.
    /// </summary>
    public class CollectionHandler : RequestHandler, ICollectionHandler
    {
        public CollectionHandler(IBggDeserializer deserializer, ILogger logger, ICollectionClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetBriefCollectionByUserName(string userName)
        {
            _logger.Information("GetBriefCollectionByUserName : {userName}", userName);

            var request = new CollectionRequest
            {
                UserName = userName,
                Brief = true
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollection(CollectionRequest request)
        {
            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionByUserName(string userName)
        {
            _logger.Information("GetCollectionByUserName : {userName}", userName);

            var request = new CollectionRequest(userName);

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionByUserNameAndId(string userName, List<long> ids)
        {
            _logger.Information("GetCollectionByUserNameAndId : {userName}, {ids}", userName, ids);

            var request = new CollectionRequest
            {
                UserName = userName,
                Id = ids
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionByUserNameAndSubtype(string userName, CollectionSubType subtype)
        {
            _logger.Information("GetCollectionByUserNameAndType : {userName}, {type}", userName, subtype);

            var request = new CollectionRequest
            {
                UserName = userName,
                Subtype = subtype
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionStatsByUserName(string userName)
        {
            _logger.Information("GetCollectionStatsByUserName : {userName}", userName);

            var request = new CollectionRequest
            {
                UserName = userName,
                Stats = true
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetPlayedCollectionByUserName(string userName)
        {
            _logger.Information("GetPlayedCollectionByUserName : {userName}", userName);

            var request = new CollectionRequest
            {
                UserName = userName,
                Played = true
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetWishListCollectionByUserName(string userName)
        {
            _logger.Information("GetWishListCollectionByUserName : {userName}", userName);

            var request = new CollectionRequest
            {
                UserName = userName,
                WishList = true
            };

            return await GetResourceFromRequestObject<Models.Collection>("collection", request);
        }
    }
}
