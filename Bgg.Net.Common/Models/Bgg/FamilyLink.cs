using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Bgg
{
    /// <summary>
    /// A link to a related item for Families
    /// </summary>
    [Serializable()]
    [ExcludeFromCodeCoverage]
    public class FamilyLink : Link
    {
        [XmlAttribute("inbound")]
        public bool Inbound { get; set; }
    }
}
