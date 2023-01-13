using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a search to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    public class SearchRequest : BggRequest
    {
        /// <summary>
        /// Returns all types of Items that match SEARCH_QUERY
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Return all items that match Query of type <see cref="SearchType"/>. 
        /// You can return multiple types
        /// </summary>
        public List<string> Type { get; set; } = new List<string>();

        /// <summary>
        /// Limit results to items that match the Query exactly
        /// </summary>
        public bool? Exact { get; set; }

        public SearchRequest(string query)
        {
            Query = query;
        }
    }
}
