namespace Bgg.Net.Common.Models.Versions
{
    /// <summary>
    /// Represents the board game version from BGG.
    /// </summary>
    public class BoardGameVersion : Version
    {
        public List<BggName> Name { get; set; }

        public int? YearPublished { get; set; }

        public string ProductCode { get; set; }

        public double? Width { get; set; }

        public double? Length { get; set; }

        public double? Depth { get; set; }

        public double? Weight { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
