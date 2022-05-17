using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;


namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents information about the Thing's name. 
    /// </summary>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("name", AnonymousType = true)]
    public class BggName
    {
        /// <summary>
        /// The string value of the name.
        /// </summary>
        [XmlAttribute("value")]
        public string Value { get; set; }

        /// <summary>
        /// The type of the name.
        /// </summary>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The sort index of the name.
        /// </summary>
        [XmlAttribute("sortindex")]
        public byte SortIndex { get; set; }
    }
}
