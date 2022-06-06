using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a family from the board game geek XmlApi2.
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("item", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class Family
    {
        /// <summary>
        /// The id of the family.
        /// </summary>
        [XmlAttribute("id")]
        public long Id { get; set; }

        /// <summary>
        /// The string link to the thumbnail.
        /// </summary>
        [XmlElement("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// The string link to the image.
        /// </summary>
        [XmlElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// The names of the family.
        /// </summary>
        [XmlElement("name")]
        public List<BggName> Name { get; set; } = new List<BggName>();

        /// <summary>
        /// The text description of the family.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Links to all the items in this family.
        /// </summary>
        [XmlElement("link")]
        public List<FamilyLink> Links { get; set; } = new List<FamilyLink>();

        /// <summary>
        /// The type of this family.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}