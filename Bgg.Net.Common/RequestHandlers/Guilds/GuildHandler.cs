using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Guilds
{
    /// <summary>
    /// Handles guild requests to the Bgg API.
    /// </summary>
    public class GuildHandler : RequestHandler, IGuildHandler
    {
        public GuildHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient)
            : base(deserializer, logger, httpClient)
        {
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

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuildExtensible(Extension extension)
        {
            return await GetResourceExtensible<Guild>("guild", Constants.SupportedGuildParameters, extension);
        }
    }
}
