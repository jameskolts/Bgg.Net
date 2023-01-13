using Bgg.Net.Common.Types;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a Thing to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ThingRequest : BggRequest
    {
        /// <summary>
        /// Specifies the id of the thing(s) to retrieve.
        /// </summary>
        public List<long> Id { get; set; } = new List<long>();

        /// <summary>
        /// Specifies that the results are filtered by the <see cref="ThingType"/>(s) regardless of id.
        /// </summary>
        public List<string> Type { get; set; } = null;

        /// <summary>
        /// Returns version info for the item if true.
        /// </summary>
        public bool? Versions { get; set; }

        /// <summary>
        /// Returns videos for the item if true.
        /// </summary>
        public bool? Videos { get; set; }

        /// <summary>
        /// Returns the ranking and rating stats for the item if true.
        /// </summary>
        public bool? Stats { get; set; }

        /// <summary>
        /// Returns marketplace data if true.
        /// </summary>
        public bool? Marketplace { get; set; }

        /// <summary>
        /// Returns all comments about the item if true.
        /// </summary>
        public bool? Comments { get; set; }

        /// <summary>
        /// Returns all ratings for the item.  
        /// </summary>
        public bool? RatingComments { get; set; }

        /// <summary>
        /// Controls the page of data to see for historical info, comments, and ratings data. 
        /// </summary>
        public int? Page { get; set; }
    }
}
