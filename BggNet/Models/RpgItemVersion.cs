namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the version of an rpg item on BGG.
    /// </summary>
    public class RpgItemVersion
    {
        public string Name { get; set; }

        public int YearPublished { get; set; }

        public string Format { get; set; }

        public string ProductCode { get; set; }

        public int? PageCount { get; set; }

        public string Isbn10 { get; set; }

        public string Isbn13 { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public string Description { get; set; }

        public List<Link> Links { get; set; }
    }
}
