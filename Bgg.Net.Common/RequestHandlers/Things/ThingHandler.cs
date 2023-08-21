using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Things
{
    /// <summary>
    /// Handles Thing requests to the BGG API.
    /// </summary>
    public class ThingHandler : RequestHandler, IThingHandler
    {
        public ThingHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
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
            var request = new ThingRequest
            {
                Id = new List<long> { id }
            };

            return await GetResourceFromRequestObject<ThingList>("thing", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ThingList>> GetThingsById(List<long> ids)
        {
            var request = new ThingRequest
            {
                Id = ids
            };

            return await GetResourceFromRequestObject<ThingList>("thing", request);
        }
    }
}
