using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Web.Client.Models;

namespace Bgg.Net.Web.Client.Components.Pages
{
    public partial class CollectionPage
    {
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

            return CoalesceCollectionData(_appState.Collection.Items, thingResponse.Item.Things);
        }

        private static List<CollectionPageItem> CoalesceCollectionData(IEnumerable<CollectionItem> items, IEnumerable<Thing> things)
        {
            var collectionPageItems = new List<CollectionPageItem>();

            foreach (var item in items)
            {
                var thing = things.Where(x => x.Id == item.Id).FirstOrDefault();

                if (thing != null)
                {
                    collectionPageItems.Add(new CollectionPageItem(item, thing));
                }
            }

            return collectionPageItems;
        }
    }
}
