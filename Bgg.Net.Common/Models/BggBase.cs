using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// The Base object for Board Game Geek Objects.
    /// </summary>
    [Serializable()]
    public abstract class BggBase
    {
        [XmlAttribute("termsofuse")]
        public string TermsOfUse { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
