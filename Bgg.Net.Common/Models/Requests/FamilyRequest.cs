using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for Family to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    public class FamilyRequest : BggRequest
    {
        /// <summary>
        /// Specifies thf
        /// </summary>
        public List<long> Id { get; set; } = new List<long>();

        /// <summary>
        /// Filters the query results by family, regardless of id.
        /// </summary>
        public List<FamilyType> Type { get; set; } = new List<FamilyType>();
    }
}
