using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

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
            _logger.LogInformation("SearchByQuery : {query}", query);

            var request = new SearchRequest(query);

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryAndType(string query, List<SearchType> type)
        {
            _logger.LogInformation("SearchByQueryAndType : {query}, {type}", query, type);

            var request = new SearchRequest(query)
            {
                Type = type.Select(x => x.ToString()).ToList()
            };

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryExact(string query)
        {
            _logger.LogInformation("SearchByQueryExact : {query}", query);

            var request = new SearchRequest(query)
            {
                Exact = true
            };

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }
    }
}
