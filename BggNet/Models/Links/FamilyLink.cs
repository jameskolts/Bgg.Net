using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models.Links
{
    /// <summary>
    /// A link to a related item for Families
    /// </summary>
    [Serializable()]
    public class FamilyLink : Link
    {
        [XmlAttribute("inbound")]
        public bool Inbound { get; set; }
    }
}
