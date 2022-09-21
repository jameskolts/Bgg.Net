using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a Forum to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ForumRequest : BggRequest
    {
        /// <summary>
        /// The id of the forum to request.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The page of the thread list to return.  
        /// </summary>
        public uint? Page { get; set; }
    }
}
