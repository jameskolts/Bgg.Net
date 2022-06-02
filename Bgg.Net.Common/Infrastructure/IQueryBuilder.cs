using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Infrastructure
{
    /// <summary>
    /// Public interface for the building of request queries.
    /// </summary>
    public interface IQueryBuilder
    {
        /// <summary>
        /// Builds a query string for the BGG API.
        /// </summary>
        /// <param name="resourceName">The name of the resource being queried.</param>
        /// <param name="request">The request to build the query with.</param>
        /// <returns>A string with the properly formatted query.</returns>
        string BuildQuery(string resourceName, BggRequest request);

    }
}
