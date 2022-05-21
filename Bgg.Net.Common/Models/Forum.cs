using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("forum", Namespace = "", IsNullable = false)]
    [ExcludeFromCodeCoverage]
    public partial class Forum : BggBase
    {                  
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("groupid")]
        public long GroupId { get; set; }

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

        [XmlAttribute("description")]
        public string Description { get; set; } 

        [XmlArray("threads")]
        [XmlArrayItem("thread")]
        public List<ForumThread> Threads { get; set; } = new List<ForumThread>();
    }
}
