using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public class ThingList : BggBase
    {
        [XmlElement("item")]
        public List<Thing> Things { get; set; } = new List<Thing>();
    }
}
