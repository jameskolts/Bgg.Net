namespace Bgg.Net.Common.Models.Versions
{
    /// <summary>
    /// A video game version as represented in BGG.
    /// </summary>
    public class VideoGameVersion : Version
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
