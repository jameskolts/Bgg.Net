using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
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
        public ThingHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
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
