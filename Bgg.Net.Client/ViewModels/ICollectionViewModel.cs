using Bgg.Net.Common.Models;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public interface ICollectionViewModel : IViewModel
    {
        public bool IsBusy { get; set; }
        public ObservableCollection<CollectionItem> Collection { get; set; }
        public Task GetCollection(string userName);
    }
}
