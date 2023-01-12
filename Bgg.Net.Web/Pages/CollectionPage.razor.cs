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
            var collectionResponse = await _collectionHandler.GetCollectionByUserName("JusticiarIV");

            var thingRequest = new ThingRequest
            {
                Id = collectionResponse.Item.Items.Select(x => x.Id).ToList(),
                Stats = true
            };

            var thingResponse = await _thingHandler.GetThing(thingRequest);

            return CollectionHelper.CoalesceCollectionData(collectionResponse.Item.Items, thingResponse.Item.Things);
        }
    }
}
