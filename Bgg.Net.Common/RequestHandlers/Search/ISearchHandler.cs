using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.RequestHandlers.Search
{
    /// <summary>
    /// Public interface for search Queries.
    /// </summary>
    public interface ISearchHandler
    {
        /// <summary>
        /// Gets a searchresult by the given query.
        /// </summary>
        /// <param name="query">What to search for.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="SearchResultList"/>.</returns>
        public Task<BggResult<SearchResultList>> SearchByQuery(string query);

        /// <summary>
        /// Gets a searchresult by the given query and type.
        /// </summary>
        /// <param name="query">What to search for.</param>
        /// <param name="type">Type filter to limit results.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="SearchResultList"/>.</returns>
        public Task<BggResult<SearchResultList>> SearchByQueryAndType(string query, List<SearchType> type);

        /// <summary>
        /// Gets a searchresult by the given query.  
        /// Only returns exact matches.
        /// </summary>
        /// <param name="query">What to search for.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="SearchResultList"/>.</returns>
        public Task<BggResult<SearchResultList>> SearchByQueryExact(string query);

        /// <summary>
        /// Gets a search result by the parameters provided in the reqquest.
        /// </summary>
        /// <param name="request">What to search for.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="SearchResultList"/>.</returns>
        public Task<BggResult<SearchResultList>> Search(SearchRequest request);
    }
}
