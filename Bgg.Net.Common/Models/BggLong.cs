using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    public class BggLong
    {
        [XmlAttribute("value")]
        public long Value { get; set; }
    }
}
