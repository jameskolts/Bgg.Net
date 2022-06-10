using Bgg.Net.Client.Models;

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
    }
}
