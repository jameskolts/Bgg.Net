using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Families
{
    /// <summary>
    /// Handles Family requests to the BGG API
    /// </summary>
    public class FamilyHandler : RequestHandler, IFamilyHandler
    {
        public FamilyHandler(IHttpClient client, ILogger logger, IBggDeserializer deserializer)
            : base(deserializer, logger, client)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyById(int id)
        {
            _logger.Information("GetFamilyById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"family?id={id}");

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIds(List<int> ids)
        {
            _logger.Information("GetFamilyByIds : {id}", ids);

            var queryString = $"family?id=" + string.Join(',', ids);

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyByIdsAndType(List<int> ids, List<FamilyType> types)
        {
            _logger.Information("GetFamilyByIdsAndType : {id}, {types}", ids, types);

            var queryString = $"family?id={string.Join(',', ids)}&type={string.Join(',', types).ToLower()}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<FamilyList>> GetFamilyExtensible(Extension extension)
        {
            _logger.Information("GetFamilyExtensible : {extensions}", extension);

            foreach (var kvp in extension.Value)
            {
                if (!Constants.SupportedFamilyQueryParameters.Contains(kvp.Key))
                {
                    string errorMessage = $"'{kvp.Key}' parameter is not supported.";
                    _logger.Error(errorMessage);

                    return new BggResult<FamilyList>
                    {
                        IsSuccessful = false,
                        Errors = new List<string> { errorMessage }
                    };
                }
            }

            string queryString = "family?" + string.Join("&", extension.Value.Select(x => x.Key + "=" + string.Join(',', x.Value)));
            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<FamilyList>(httpResponseMessage);
        }
    }
}
