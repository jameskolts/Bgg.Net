using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Search
{
    /// <summary>
    /// Handles search requests to the BGG API.
    /// </summary>
    public class SearchHandler : RequestHandler, ISearchHandler
    {
        public SearchHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> Search(SearchRequest request)
        {
            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQuery(string query)
        {
            _logger.Information("SearchByQuery : {query}", query);

            var httpResponseMessage = await _httpClient.GetAsync($"search?query={query}");

            return await BuildBggResult<SearchResultList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryAndType(string query, List<SearchType> type)
        {
            _logger.Information("SearchByQueryAndType : {query}, {type}", query, type);

            var httpResponseMessage = await _httpClient.GetAsync($"search?query={query}&type={string.Join(",", type.Select(x => x.ToString().ToLower()))}");

            return await BuildBggResult<SearchResultList>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryExact(string query)
        {
            _logger.Information("SearchByQueryExact : {query}", query);

            var httpResponseMessage = await _httpClient.GetAsync($"search?query={query}&exact=1");

            return await BuildBggResult<SearchResultList>(httpResponseMessage);
        }
    }
}
