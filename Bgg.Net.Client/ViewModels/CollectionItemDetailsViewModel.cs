using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Client.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public class CollectionItemDetailsViewModel : ViewModelBase, ICollectionItemDetailsViewModel
    {
        public CollectionItemDetailsViewModel()
        {
        }

        public CollectionItemDetailsViewModel(CollectionPageItem item)
        {
            Item = item;
        }
    
        public CollectionPageItem Item { get; private set; }

        public long? BggRank
        {
            get => Item?.Statistics.Ratings.Ranks.FirstOrDefault(x => x.Name == "boardgame")?.Value;
        }
    }
}
