using Bgg.Net.Common.Models;

namespace Bgg.Net.Web.Models
{
    /// <summary>
    /// An item to be displayed on the Collection Page
    /// </summary>
    public class CollectionPageItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int YearPublished { get; set; }

        public string Image { get; set; }

        public int NumPlays { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public int PlayTime { get; set; }

        public int MinAge { get; set; }

        public string Description { get; set; }

        public List<string>? Publishers { get; set; }

        public List<string>? Mechanics { get; set; }

        public List<string>? Designers { get; set; }

        public List<string>? Artists { get; set; }

        public CollectionItemStatus Status { get; set; }

        public Statistics Statistics { get; set; }

        public CollectionPageItem(CollectionItem item, Thing thing)
        {
            Id = thing.Id;
            YearPublished = thing.YearPublished.Value;
            Image = thing.Image;
            NumPlays = item.NumPlays;
            MinPlayers = thing.MinPlayers.Value;
            MaxPlayers = thing.MaxPlayers.Value;
            PlayTime = thing.MaxPlayTime.Value;
            MinAge = thing.MinAge.Value;
            Description = thing.Description;
            Name = item.Name;
            Publishers = thing.Links?.Where(x => x.Type == "boardgamepublisher")?.Select(x => x.Value)?.ToList();
            Mechanics = thing.Links?.Where(x => x.Type == "boardgamemechanic")?.Select(x => x.Value)?.ToList();
            Designers = thing.Links?.Where(x => x.Type == "boardgamedesigner")?.Select(x => x.Value)?.ToList();
            Artists = thing.Links?.Where(x => x.Type == "boardgameartist")?.Select(x => x.Value)?.ToList();
            Status = item.Status;
            Statistics = thing.Statistics;
        }
    }
}
