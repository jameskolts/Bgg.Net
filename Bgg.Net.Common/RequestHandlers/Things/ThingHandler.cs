using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
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
        public ThingHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient )
            : base(deserializer, logger, httpClient)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThing(ThingRequest request)
        {
            return await GetResourceFromRequestObject<ThingList>("thing", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingById(long id)
        {
            _logger.Information("GetThingById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"thing?id={id}");

            return await BuildBggResult<ThingList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingsById(List<long> ids)
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
