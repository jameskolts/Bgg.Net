using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Player
    {
        /// <summary>
        /// The BggUserName for this player, if any.
        /// </summary>
        [XmlAttribute("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The id for this player.
        /// </summary>
        [XmlAttribute("userid")]
        public long Id { get; set; }

        /// <summary>
        /// The real name for this player.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Which position did this player start in.
        /// </summary>
        [XmlAttribute("startposition")]
        public string StartPosition { get; set; }

        /// <summary>
        /// What color did this player use.
        /// </summary>
        [XmlAttribute("color")]
        public string Color { get; set; }

        /// <summary>
        /// The player's final score.
        /// </summary>
        [XmlAttribute("score")]
        public string Score { get; set; }

        /// <summary>
        /// True if the player was new to the game.
        /// </summary>
        [XmlAttribute("new")]
        public bool New { get; set; }

        /// <summary>
        /// This player's rating of the game.
        /// </summary>
        [XmlAttribute("rating")]
        public string Rating { get; set; }

        /// <summary>
        /// True if this player won the game.
        /// </summary>
        [XmlAttribute("win")]
        public bool Win { get; set; }
    }
}
