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
        public CollectionHandler(IBggDeserializer deserializer, ILogger logger, ICollectionClient httpClient, IRequestValidatorFactory validatorFactory)
            : base(deserializer, logger, httpClient, validatorFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetBriefCollectionByUserName(string userName)
        {
            _logger.Information("GetBriefCollectionByUserName : {userName}", userName);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&brief=1");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
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

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionByUserNameAndId(string userName, List<long> ids)
        {
            _logger.Information("GetCollectionByUserNameAndId : {userName}, {ids}", userName, ids);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&id={string.Join(",", ids)}");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionByUserNameAndType(string userName, CollectionSubType type)
        {
            _logger.Information("GetCollectionByUserNameAndType : {userName}, {type}", userName, type);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&type={type.ToString().ToLower()}");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionExtensible(Extension extension)
        {
            return await GetResourceExtensible<Models.Collection>("collection", Constants.SupportedCollectionParameters, extension);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetCollectionStatsByUserName(string userName)
        {
            _logger.Information("GetCollectionStatsByUserName : {userName}", userName);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&stats=1");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }


        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetPlayedCollectionByUserName(string userName)
        {
            _logger.Information("GetPlayedCollectionByUserName : {userName}", userName);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&played=1");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Models.Collection>> GetWishListCollectionByUserName(string userName)
        {
            _logger.Information("GetWishListCollectionByUserName : {userName}", userName);

            var httpResponseMessage = await _httpClient.GetAsync($"collection?username={userName}&wishlist=1");

            return await BuildBggResult<Models.Collection>(httpResponseMessage);
        }
    }
}
