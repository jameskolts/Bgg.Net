using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Things
{
    /// <summary>
    /// Handles Thing requests to the BGG API.
    /// </summary>
    public class ThingHandler : RequestHandler, IThingHandler
    {
        public ThingHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory)
            : base(deserializer, logger, httpClient, validatorFactory)
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
