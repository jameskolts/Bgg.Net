using Bgg.Net.Common.Types;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a "Thing" from the board game geek XmlApi2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("item")]
    [ExcludeFromCodeCoverage]
    public class Thing
    {
        /// <summary>
        /// The id of the thing.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The type of the thing.
        /// </summary>
        /// <remarks>
        /// Should be assignable to one of <seealso cref="ThingType"/>.
        /// </remarks>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// Url of a thumbnail of the thing.
        /// </summary>
        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// The image of the thing.
        /// </summary>
        [XmlElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// Any applicable names for the thing.
        /// </summary>
        [XmlElement("name")]
        public List<BggName> Name { get; set; } = new();

        /// <summary>
        /// A description of the thing.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Year the thing was published.
        /// </summary>
        [XmlElement("yearpublished")]
        public BggInteger YearPublished { get; set; }

        /// <summary>
        /// Minimum number of players.
        /// </summary>
        [XmlElement("minplayers")]
        public BggInteger MinPlayers { get; set; }

        /// <summary>
        /// Maximum number of players.
        /// </summary>
        [XmlElement("maxplayers")]
        public BggInteger MaxPlayers { get; set; }

        /// <summary>
        /// The typical playing time the thing will take.
        /// </summary>
        [XmlElement("playingtime")]
        public BggInteger PlayingTime { get; set; }

        /// <summary>
        /// The mimium playing time the thing will take.
        /// </summary>
        [XmlElement("minplaytime")]
        public BggInteger MinPlayTime { get; set; }

        /// <summary>
        /// The maximum playing time the thing will take.
        /// </summary>
        [XmlElement("maxplaytime")]
        public BggInteger MaxPlayTime { get; set; }

        /// <summary>
        /// The minimum recommended age.
        /// </summary>
        [XmlElement("minage")]
        public BggInteger MinAge { get; set; }

        /// <summary>
        /// Any associated links of the thing.
        /// </summary>
        [XmlElement("link")]
        public List<Link> Links { get; set; } = new();

        /// <summary>
        /// Any additional versions of the thing.
        /// </summary>
        [XmlArray("versions")]
        [XmlArrayItem("item")]
        public List<Version> Versions { get; set; } = new();

        /// <summary>
        /// A list of all the polls associated with a thing.
        /// </summary>
        [XmlElement("poll")]
        public List<Poll> Poll { get; set; } = new();

        /// <summary>
        /// User comments regarding the thing.
        /// </summary>
        [XmlElement("comments")]
        public CommentList Comments { get; set; }

        /// <summary>
        /// The listings in the bgg marketplace for a thing.
        /// </summary>
        [XmlArray("marketplacelistings")]
        [XmlArrayItem("listing")]
        public List<Listing> MarketplaceListing { get; set; } = new();

        /// <summary>
        /// The videos associated with the thing.
        /// </summary>
        [XmlElement("videos")]
        public VideoList Videos { get; set; }

        /// <summary>
        /// The statistics associated with the thing.
        /// </summary>
        [XmlElement("statistics")]
        public Statistics Statistics { get; set; }
    }
}

