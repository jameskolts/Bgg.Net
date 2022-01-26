using Version = Bgg.Net.Common.Models.Versions.Version;

namespace Bgg.Net.Common.Models
{
    public class Thing : BggBase
    {
        public int? Id { get; set; }

        public string Type { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }

        public List<BggName> Name { get; set; } = new List<BggName>();

        public string Description { get; set; }

        public int? YearPublished { get; set; }

        public int? MinPlayers { get; set; }

        public int? MaxPlayers { get; set; }

        public List<Poll> Poll { get; set; } = new List<Poll>();

        public int? PlayingTime { get; set; }

        public int? MinPlayTime { get; set; }

        public int? MaxPlayTime { get; set; }

        /// <summary>
        /// The minimum recommended age.
        /// </summary>
        public int? MinAge { get; set; }

        public List<Link> Link { get; set; } = new List<Link>();

        public List<Version> Versions { get; set; } = new List<Version>();

        public Comments Comments { get; set; }

        public List<Listing> MarketplaceListing { get; set; } = new List<Listing>();
    }
}


