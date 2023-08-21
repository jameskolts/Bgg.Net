using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
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
        public SearchHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
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
            var request = new SearchRequest(query);

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryAndType(string query, List<SearchType> type)
        {
            var request = new SearchRequest(query)
            {
                Type = type.Select(x => x.ToString()).ToList()
            };

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<SearchResultList>> SearchByQueryExact(string query)
        {
            var request = new SearchRequest(query)
            {
                Exact = true
            };

            return await GetResourceFromRequestObject<SearchResultList>("search", request);
        }
    }
}
