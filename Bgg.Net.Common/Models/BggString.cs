using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;


namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BggString
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
