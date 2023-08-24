using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// Represents a play of a game from the BGG XmlApi 2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Play
    {
        /// <summary>
        /// The id of the play.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The date of the play.
        /// </summary>
        [XmlAttribute("date")]
        public string Date { get; set; }

        /// <summary>
        /// The number of plays that occurred.
        /// </summary>
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// How long the play took.
        /// </summary>
        [XmlAttribute("length")]
        public int Length { get; set; }

        /// <summary>
        /// True if the play was not complete.
        /// </summary>
        [XmlAttribute("incomplete")]
        public bool Incomplete { get; set; }

        /// <summary>
        /// TODO: Determine what this indicates.
        /// </summary>
        [XmlAttribute("nowinstats")]
        public bool NowInStats { get; set; }

        /// <summary>
        /// The item that was played.
        /// </summary>
        [XmlElement("item")]
        public PlayItem Item { get; set; }

        /// <summary>
        /// Additional user comments about this play.
        /// </summary>
        [XmlElement("comments")]
        public string Comment { get; set; }

        /// <summary>
        /// The players that participated in this play.
        /// </summary>
        [XmlArray("players")]
        [XmlArrayItem("player")]
        public List<Player> Players { get; set; } = new();
    }
}
