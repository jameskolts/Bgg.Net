using Bgg.Net.Client.Models;

namespace Bgg.Net.Client.ViewModels
{
    public interface ICollectionItemDetailsViewModel : IViewModel
    {
        public CollectionPageItem Item { get; }
    }
}
