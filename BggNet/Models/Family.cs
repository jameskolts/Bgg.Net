using Bgg.Net.Common.Models.Links;

namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents a family item from bgg.
    /// </summary>
    public class Family : BggBase
    {
        public int? Id { get; set; } 

        public string Type { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }

        public List<BggName> Name { get; set; } = new List<BggName>();

        public string Description { get; set; }

        public List<FamilyLink> Link { get; set; } = new List<FamilyLink>();
    }
}
