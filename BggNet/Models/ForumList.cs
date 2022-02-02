using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Models
{
    public class ForumList
    {
        public int? Id { get; set; }

        public string Type { get; set; }

        public List<Forum> Forums { get; set; } = new List<Forum>();
    }
}
