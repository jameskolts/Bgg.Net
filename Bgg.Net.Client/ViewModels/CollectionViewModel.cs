using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Client.Infrastructure.Helpers;
using Bgg.Net.Client.Models;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Things;
using Serilog;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    public class CollectionViewModel : ViewModelBase, ICollectionViewModel
    {
        private readonly ILogger _logger;
        private readonly ICollectionHandler _collectionHandler;
        private readonly IThingHandler _thingHandler;
        private readonly ICollectionHelper _collectionHelper;

        private ObservableCollection<CollectionPageItem> _collection;
        private bool _isBusy;

        public CollectionViewModel(ILogger logger, ICollectionHandler collectionHandler, IThingHandler thingHandler,
            ICollectionHelper collectionHelper)
        {
            _logger = logger;
            _collectionHandler = collectionHandler;
            _collectionHelper = collectionHelper;
            _thingHandler = thingHandler;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); }
        }

        public ObservableCollection<CollectionPageItem> Collection
        {
            get { return _collection; }
            set { _collection = value; OnPropertyChanged(nameof(Collection)); }
        }

        public async Task GetCollection(string userName)
        {
            IsBusy = true;

            try
            {
                var collectionResponse = await _collectionHandler.GetCollectionByUserName(userName);
                var things = await _thingHandler.GetThingsById(collectionResponse.Item.Items.Select(x => x.Id).ToList());

                Collection = _collectionHelper.CoalesceCollectionData(collectionResponse.Item.Items, things.Item.Things);

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
