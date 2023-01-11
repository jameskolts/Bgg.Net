using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Families
{
    /// <summary>
    /// Handles Family requests to the BGG API.
    /// </summary>
    public class FamilyHandler : RequestHandler, IFamilyHandler
    {
        public FamilyHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient client, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, client, validatorFactory, queryBuilder)
        {
        }

        public async Task<BggResult<FamilyList>> GetFamily(FamilyRequest request)
        {
            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyById(long id)
        {
            _logger.LogInformation("GetFamilyById : {id}", id);

            var request = new FamilyRequest
            {
                Id = new List<long> { id }
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIds(List<long> ids)
        {
            _logger.LogInformation("GetFamilyByIds : {id}", ids);

            var request = new FamilyRequest
            {
                Id = ids
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<long> ids, List<FamilyType> types)
        {
            _logger.LogInformation("GetFamilyByIdsAndType : {id}, {types}", ids, types);

            var request = new FamilyRequest
            {
                Id = ids,
                Type = types
            };

            return await GetResourceFromRequestObject<FamilyList>("family", request); ;
        }
    }
}
