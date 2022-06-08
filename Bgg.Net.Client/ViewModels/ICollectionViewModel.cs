using Bgg.Net.Client.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public interface ICollectionViewModel : IViewModel
    {
        public bool IsBusy { get; set; }
        public ObservableCollection<CollectionPageItem> Collection { get; set; }
        public Task GetCollection(string userName);
        public void FilterCollection(string name);
    }
}
