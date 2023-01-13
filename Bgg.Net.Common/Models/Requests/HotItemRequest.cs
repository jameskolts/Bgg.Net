using Bgg.Net.Common.Types;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for HotItem to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class HotItemRequest : BggRequest
    {
        /// <summary>
        /// The <see cref="HotItemType"/> of hot items to retrieve.
        /// </summary>
        public string Type { get; set; }

        public HotItemRequest(string type)
        {
            Type = type;
        }
    }
}
