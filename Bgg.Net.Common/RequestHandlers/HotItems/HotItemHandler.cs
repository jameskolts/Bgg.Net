using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.HotItems
{
    /// <summary>
    /// Hanndles HotItem queries to the BGG API.
    /// </summary>
    public class HotItemHandler : RequestHandler, IHotItemsHandler
    {
        public HotItemHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<HotItemList>> GetHotItems(HotItemRequest request)
        {
            return await GetResourceFromRequestObject<HotItemList>("hot", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<HotItemList>> GetHotItemsByType(HotItemType type)
        {
            var request = new HotItemRequest(type.ToString());

            return await GetResourceFromRequestObject<HotItemList>("hot", request);
        }
    }
}
