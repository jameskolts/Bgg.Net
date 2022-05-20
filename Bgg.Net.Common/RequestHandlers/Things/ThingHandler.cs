using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Things
{
    /// <summary>
    /// Handles Thing requests to the BGG API.
    /// </summary>
    public class ThingHandler : RequestHandler, IThingHandler
    {
        /// <summary>
        /// Creates an instance of <see cref="ThingHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ThingHandler(IHttpClient httpClient, ILogger logger, IBggDeserializer deserializer)
            : base(deserializer, logger, httpClient)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingById(int id)
        {
            _logger.Information("GetThingById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"thing?id={id}");

            return await BuildBggResult<ThingList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingsById(List<int> ids)
        {
            _logger.Information("GetThingById : {id}", ids);

            var queryString = $"thing?id=" + string.Join(',', ids);

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<ThingList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingsExtensible(Extension extension)
        {
            return await GetResourceExtensible<ThingList>("thing", Constants.SupportedThingQueryParameters, extension);
        }
    }
}
