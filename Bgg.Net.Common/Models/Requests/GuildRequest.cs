using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a Guild to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    public class GuildRequest : BggRequest
    {
        /// <summary>
        /// ID of the guild to query.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// True to include member roster in the results. 
        /// Member list is paged and sorted.
        /// </summary>
        public bool? Members { get; set; }

        /// <summary>
        /// Specifies the <see cref="SortType"/> of the members list.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// The page of the members list to return.
        /// </summary>
        public int? Page { get; set; }

        public GuildRequest()
        {

        }

        public GuildRequest(long id)
        {
            Id = id;
        }
    }
}
