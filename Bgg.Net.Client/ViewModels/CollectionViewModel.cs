using Bgg.Net.Client.Infrastructure.Extensions;
using Bgg.Net.Client.Infrastructure.Helpers;
using Bgg.Net.Client.Models;
using Bgg.Net.Common.RequestHandlers.Collection;
using Bgg.Net.Common.RequestHandlers.Things;
using Serilog;
using System.Collections.ObjectModel;

namespace Bgg.Net.Client.ViewModels
{
    /// <summary>
    /// ViewModel for the Collection Page
    /// </summary>
    public class CollectionViewModel : ViewModelBase, ICollectionViewModel
    {
        private readonly ILogger _logger;
        private readonly ICollectionHandler _collectionHandler;
        private readonly ICollectionHelper _collectionHelper;
        private readonly IThingHandler _thingHandler;

        private ObservableCollection<CollectionPageItem> _collection = new();
        private IEnumerable<CollectionPageItem> _fullCollection;
        private bool _isBusy;

        public CollectionViewModel(ILogger logger, ICollectionHandler collectionHandler, IThingHandler thingHandler,
            ICollectionHelper collectionHelper)
        {
            _logger = logger;
            _collectionHandler = collectionHandler;
            _collectionHelper = collectionHelper;
            _thingHandler = thingHandler;
        }

        /// <summary>
        /// True if the ViewModel is querying data.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); }
        }

        /// <summary>
        /// The Collection to display.
        /// </summary>
        public ObservableCollection<CollectionPageItem> Collection
        {
            get { return _collection; }
            set { _collection = value; OnPropertyChanged(nameof(Collection)); }
        }

        /// <summary>
        /// Loads the <see cref="Collection"/> property for the given user.
        /// </summary>
        /// <param name="userName">The user to load a collection for.</param>
        public async Task GetCollection(string userName)
        {
            IsBusy = true;

            try
            {
                var collectionResponse = await _collectionHandler.GetCollectionByUserName(userName);
                var thingResponse = await _thingHandler.GetThingsById(collectionResponse.Item.Items.Select(x => x.Id).ToList());

                _fullCollection = _collectionHelper.CoalesceCollectionData(collectionResponse.Item.Items, thingResponse.Item.Things);
                Collection = _fullCollection.ToObservableCollection();

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

        //TODO: Make this work
        public void FilterCollection(string name, string age, string playercount, string time)
        {
            IsBusy = true;

            IEnumerable<CollectionPageItem> query = _fullCollection;

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name)).ToList();
            }

            if (int.TryParse(age, out int parsedAge))
            {
                query = query.Where(x => x.MinAge >= parsedAge);
            }

            if (int.TryParse(playercount, out int parsedPlayercount))
            {
                query = query.Where(x => x.MinPlayers >= parsedPlayercount).ToList();
            }

            if (int.TryParse(time, out int parsedTime))
            {
                query = query.Where(x => x.PlayTime <= parsedTime).ToList();
            }

            IsBusy = false;
            Collection = query.ToObservableCollection();
        }
    }
}
