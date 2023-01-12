using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Web.Infrastructure.Helpers;
using Bgg.Net.Web.Models;

namespace Bgg.Net.Web.Pages
{
    public partial class CollectionPage
    {
        private readonly CollectionHelper _collectionHelper = new();
        public List<CollectionPageItem>? Collection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //TODO: Remove the hardcoded user for a logged in user.
            Collection = await GetCollection("JusticiarIV");

            await base.OnInitializedAsync();
        }

        private async Task<List<CollectionPageItem>> GetCollection(string userName)
        {
            if (_appState.Collection == null)
            {
                var collectionResponse = await _collectionHandler.GetCollectionByUserName(userName);
                _appState.Collection = collectionResponse.Item;
            }

            var thingRequest = new ThingRequest
            {
                Id = _appState.Collection.Items.Select(x => x.Id).ToList(),
                Stats = true
            };

            var thingResponse = await _thingHandler.GetThing(thingRequest);

            return CollectionHelper.CoalesceCollectionData(_appState.Collection.Items, thingResponse.Item.Things);
        }
    }
}
