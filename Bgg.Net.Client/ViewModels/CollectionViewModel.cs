using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.Collection;
using Serilog;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public class CollectionViewModel : ViewModelBase, ICollectionViewModel
    {
        private readonly ILogger _logger;
        private readonly ICollectionHandler _collectionHandler;
        private ObservableCollection<CollectionItem> _collection;
        private bool _isBusy;

        public CollectionViewModel(ILogger logger, ICollectionHandler collectionHandler)
        {
            _logger = logger;
            _collectionHandler = collectionHandler;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); }
        }

        public ObservableCollection<CollectionItem> Collection
        {
            get { return _collection; }
            set { _collection = value; OnPropertyChanged(nameof(Collection)); }
        }

        public async Task GetCollection(string userName)
        {
            try
            {
                IsBusy = true;

                var collectionResponse = await _collectionHandler.GetCollectionByUserName(userName);
                Collection = collectionResponse.Item.Items.ToObservableCollection();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
