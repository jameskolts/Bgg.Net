using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Guilds
{
    /// <summary>
    /// Handles guild requests to the Bgg API.
    /// </summary>
    public class GuildHandler : RequestHandler, IGuildHandler
    {
        public GuildHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuild(GuildRequest request)
        {
            return await GetResourceFromRequestObject<Guild>("guild", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuildById(long id)
        {
            _logger.Information("GetGuildById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"guild?id={id}");

            return await BuildBggResult<Guild>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuildByIdWithMembers(long id, SortType sortType = SortType.UserName, int page = 1)
        {
            _logger.Information("GetGuildByIdWithMembers : {id}, {sortType}, {page}", id, sortType, page);

            var httpResponseMessage =
                await _httpClient.GetAsync($"guild?id={id}&members=1&sort={sortType.ToString().ToLower()}&page={page}");

            return await BuildBggResult<Guild>(httpResponseMessage);
        }
    }
}
