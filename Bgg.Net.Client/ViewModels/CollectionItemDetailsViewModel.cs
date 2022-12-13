using Bgg.Net.Client.Models;
using Microsoft.VisualStudio.PlatformUI;

namespace Bgg.Net.Client.ViewModels
{
    public class CollectionItemDetailsViewModel : ViewModelBase, ICollectionItemDetailsViewModel
    {
        public CollectionPageItem Item { get; private set; }

        public CollectionItemDetailsViewModel()
        {
        }

        public CollectionItemDetailsViewModel(CollectionPageItem item)
        {
            Item = item;
        }

        public long? BggRank
        {
            get => Item?.Statistics.Ratings.Ranks.FirstOrDefault(x => x.Name == "boardgame")?.Value ?? -1;
        }
    }
}
