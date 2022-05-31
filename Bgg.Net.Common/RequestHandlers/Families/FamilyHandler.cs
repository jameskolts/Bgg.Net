using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Families
{
    /// <summary>
    /// Handles Family requests to the BGG API.
    /// </summary>
    public class FamilyHandler : RequestHandler, IFamilyHandler
    {
        public FamilyHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient client, IRequestValidatorFactory validatorFactory)
            : base(deserializer, logger, client, validatorFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyById(long id)
        {
            _logger.Information("GetFamilyById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"family?id={id}");

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIds(List<long> ids)
        {
            _logger.Information("GetFamilyByIds : {id}", ids);

            var queryString = $"family?id=" + string.Join(',', ids);

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<long> ids, List<FamilyType> types)
        {
            _logger.Information("GetFamilyByIdsAndType : {id}, {types}", ids, types);

            var queryString = $"family?id={string.Join(',', ids)}&type={string.Join(',', types).ToLower()}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyExtensible(Extension extension)
        {
            return await GetResourceExtensible<FamilyList>("family", Constants.SupportedFamilyQueryParameters, extension);
        }
    }
}
