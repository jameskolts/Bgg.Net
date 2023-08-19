using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType("item", AnonymousType = true)]
    [ExcludeFromCodeCoverage]
    public class HotItem
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("rank")]
        public int Rank { get; set; }

        [XmlElement("thumbnail")]
        public BggString Thumbnail { get; set; }

        [XmlElement("name")]
        public BggString Name { get; set; }

        [XmlElement("yearpublished")]
        public BggInteger YearPublished { get; set; }
    }
}
