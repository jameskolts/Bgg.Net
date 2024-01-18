using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Families
{
    /// <summary>
    /// Handles Family requests to the BGG API.
    /// </summary>
    public class FamilyHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient client, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder) : RequestHandler(deserializerFactory, logger, client, validatorFactory, queryBuilder), IFamilyHandler
    {
        public async Task<BggResult<FamilyList>> GetFamily(FamilyRequest request)
        {
            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyById(long id)
        {
            var request = new FamilyRequest
            {
                Id = new List<long> { id }
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIds(List<long> ids)
        {
            var request = new FamilyRequest
            {
                Id = ids
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<long> ids, List<FamilyType> types)
        {
            var request = new FamilyRequest
            {
                Id = ids,
                Type = types.Select(x => x.ToString()).ToList()
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request); ;
        }
    }
}
