using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

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
        public async Task<BggResult<HotItemList>> GetHotItemsByType(HotItemType type)
        {
            _logger.Information("GetHotItemsByType : {type}", type);

            var httpResponseMessage = await _httpClient.GetAsync($"hot?type={type.ToString().ToLower()}");

            return await BuildBggResult<HotItemList>(httpResponseMessage);
        }
    }
}
