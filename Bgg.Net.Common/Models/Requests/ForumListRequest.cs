using Bgg.Net.Common.Types;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for ForumList to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ForumListRequest : BggRequest
    {
        /// <summary>
        /// Specifies the id of the type of database entry you want the forum list for.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Specifies the <see cref="ItemType"/> of the item.
        /// </summary>
        public string Type { get; set; }
    }
}
