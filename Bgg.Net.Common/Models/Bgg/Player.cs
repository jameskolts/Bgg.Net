using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
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
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// The id for this player.
        /// </summary>
        [XmlAttribute("userid")]
        [JsonProperty("userid")]
        public long Id { get; set; }

        /// <summary>
        /// The real name for this player.
        /// </summary>
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Which position did this player start in.
        /// </summary>
        [XmlAttribute("startposition")]
        [JsonProperty("startposition")]
        public string StartPosition { get; set; }

        /// <summary>
        /// What color did this player use.
        /// </summary>
        [XmlAttribute("color")]
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// The player's final score.
        /// </summary>
        [XmlAttribute("score")]
        [JsonProperty("score")]
        public string Score { get; set; }

        /// <summary>
        /// True if the player was new to the game.
        /// </summary>
        [XmlAttribute("new")]
        [JsonProperty("new")]
        public bool New { get; set; }

        /// <summary>
        /// This player's rating of the game.
        /// </summary>
        [XmlAttribute("rating")]
        [JsonProperty("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// True if this player won the game.
        /// </summary>
        [XmlAttribute("win")]
        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
