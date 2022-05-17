﻿using System.ComponentModel;
using System.Xml.Serialization;

namespace Bgg.Net.Common.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(TypeName = "thread", AnonymousType = true)]
    public partial class ForumThread
    {
        
        [XmlAttribute("id")]
        public long Id { get; set; }
        
        [XmlAttribute("subject")]
        public string Subject { get; set; }

        [XmlAttribute("author")]
        public string Author { get; set; }
                
        [XmlAttribute("numarticles")]
        public long NumArticles { get; set; }
                
        [XmlAttribute("postdate")]
        public string PostDate { get; set; }
                
        [XmlAttribute("lastpostdate")]
        public string LastPostDate { get; set; }
    }
}
