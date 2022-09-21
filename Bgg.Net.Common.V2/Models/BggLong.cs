using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [ExcludeFromCodeCoverage]
    public class BggLong
    {
        [XmlAttribute("value")]
        public long Value { get; set; }
    }
}
