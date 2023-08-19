using Bgg.Net.Common.Models.Bgg;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a guild in the BGG Xml API 2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("guild", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class Guild : BggBase
    {
        /// <summary>
        /// The id of the guild.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The name of the guild.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The date the guild was created.
        /// </summary>
        [XmlAttribute("created")]
        public string Created { get; set; }

        /// <summary>
        /// The category of the guild.
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        /// The guilds web address.
        /// </summary>
        [XmlElement("website")]
        public string Website { get; set; }

        /// <summary>
        /// Who manages the guild on BGG.
        /// </summary>
        [XmlElement("manager")]
        public string Manager { get; set; }

        /// <summary>
        /// A description of the guild.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// The guilds location/address.
        /// </summary>
        [XmlElement("location")]
        public Location Location { get; set; }

        [XmlElement("members")]
        public GuildMemberList Members { get; set; }
    }
}
