using System.ComponentModel;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("forum", Namespace = "", IsNullable = false)]
    public partial class Forum : BggBase
    {
        [XmlArray("threads")]
        [XmlArrayItem("thread")]
        public ForumThread[] Threads { get; set; }
                
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
                
        [XmlAttribute("numthreads")]
        public long NumThreads { get; set; }

        [XmlAttribute("numposts")]
        public long NumPosts { get; set; }  

        [XmlAttribute("lastpostdate")]
        public string LastPostDate { get; set; }
                
        [XmlAttribute("noposting")]
        public bool NoPosting { get; set; }

        [XmlAttribute("termsofuse")]
        public string TermsOfUse { get; set; }
    }
}
