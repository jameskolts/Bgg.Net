using Bgg.Net.Client.Models;

namespace Bgg.Net.Client.ViewModels
{
    public interface ICollectionItemDetailsViewModel : IViewModel
    {
        CollectionPageItem Item { get; }
        long? BggRank { get; }
    }
}
