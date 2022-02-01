using Version = Bgg.Net.Common.Models.Versions.Version;
using Bgg.Net.Common.Models.Polls;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a "Thing" from the board game geek XmlApi2
    /// </summary>
    public class Thing : BggBase
    {
        /// <summary>
        /// The id of the thing.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The type of the thing.
        /// </summary>
        /// <remarks>
        /// Should be assignable to one of <seealso cref="ThingType"/>.
        /// </remarks>
        public string Type { get; set; }

        /// <summary>
        /// Url of a thumbnail of the thing.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// The image of the thing.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Any applicable names for the thing.
        /// </summary>
        public List<BggName> Name { get; set; } = new List<BggName>();

        /// <summary>
        /// A description of the thing.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Year the thing was published.
        /// </summary>
        public int? YearPublished { get; set; }

        /// <summary>
        /// Minimum number of players.
        /// </summary>
        public int? MinPlayers { get; set; }

        /// <summary>
        /// Maximum number of players.
        /// </summary>
        public int? MaxPlayers { get; set; }

        /// <summary>
        /// A list of all the polls associated with an thing.
        /// </summary>
        public List<Poll> Poll { get; set; } = new List<Poll>();

        /// <summary>
        /// The typical playing time the thing will take.
        /// </summary>
        public int? PlayingTime { get; set; }

        /// <summary>
        /// The mimium playing time the thing will take.
        /// </summary>
        public int? MinPlayTime { get; set; }

        /// <summary>
        /// The maximum playing time the thing will take.
        /// </summary>
        public int? MaxPlayTime { get; set; }

        /// <summary>
        /// The minimum recommended age.
        /// </summary>
        public int? MinAge { get; set; }

        /// <summary>
        /// Any associated links of the thing.
        /// </summary>
        public List<Link> Link { get; set; } = new List<Link>();

        /// <summary>
        /// Any additional versions of the thing.
        /// </summary>
        public List<Version> Versions { get; set; } = new List<Version>();

        /// <summary>
        /// User comments regarding the thing.
        /// </summary>
        public Comments Comments { get; set; }

        /// <summary>
        /// The listings in the bgg marketplace for a thing.
        /// </summary>
        public List<Listing> MarketplaceListing { get; set; } = new List<Listing>();

        /// <summary>
        /// The videos associated with the thing.
        /// </summary>
        public Videos Videos { get; set; }

        /// <summary>
        /// The statistics associated with the thing.
        /// </summary>
        public Statistics Statistics { get; set; }
    }
}


