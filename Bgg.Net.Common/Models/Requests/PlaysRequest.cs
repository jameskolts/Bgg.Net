using Bgg.Net.Common.Types;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for plays to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    /// <remarks>Must include either a username; or an id and type to get results.</remarks>
    [ExcludeFromCodeCoverage]
    public class PlaysRequest : BggRequest
    {
        /// <summary>
        /// Name of the player you want to request play information for.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Id number of the item you want to request play information for.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of the item you want to request play information for.
        /// </summary>
        public ItemType? Type { get; set; }

        /// <summary>
        /// Returns only plays of the specified date or later.
        /// </summary>
        public DateOnly? MinDate { get; set; }

        /// <summary>
        /// Returns only plays of the specified date or earlier.
        /// </summary>
        public DateOnly? MaxDate { get; set; }

        /// <summary>
        /// Limits play results to the specified type.
        /// </summary>
        public ItemSubType? SubType { get; set; }

        /// <summary>
        /// The page of information to request. Page size is 100 records.
        /// </summary>
        public int? Page { get; set; }
    }
}
