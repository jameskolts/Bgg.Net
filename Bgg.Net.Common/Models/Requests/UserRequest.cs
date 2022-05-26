using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a User to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    public class UserRequest : BggRequest
    {
        /// <summary>
        /// Specifies the user name (only one user is requestable at a time).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Turns on optional buddies reporting. Results are paged; see page parameter.
        /// </summary>
        public bool? Buddies { get; set; }

        /// <summary>
        /// Turns on optional guilds reporting. Results are paged; see page parameter.
        /// </summary>
        public bool? Guilds { get; set; }

        /// <summary>
        /// Include the user's hot 10 list from their profile. Ommitted if they haven't set it.
        /// </summary>
        public bool? Hot { get; set; }

        /// <summary>
        /// Include the user's top 10 list from their profile. Omitted if empty.
        /// </summary>
        public bool? Top { get; set; }

        /// <summary>
        /// Controls the domain for the users hot 10 and top 10 lists. The DOMAIN default is boardgame.
        /// </summary>
        public DomainType? Domain { get; set; }

        /// <summary>
        /// Specifies the page of buddy and guild results to return. 
        /// The default page is 1 if unspecified.  If you request a page that doesn't exist it will be empty.
        /// </summary>
        public uint? Page { get; set; }

        public UserRequest(string name)
        {
            Name = name;
        }
    }
}
