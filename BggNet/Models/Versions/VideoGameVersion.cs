namespace Bgg.Net.Common.Models.Versions
{
    public class VideoGameVersion : Version
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Link> Links { get; set; } = new List<Link>();
    }
}
