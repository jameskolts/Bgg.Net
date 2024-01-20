using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Web.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Client.Components.Pages
{
    public partial class CollectionItemDetailPage
    {
        [Parameter]
        public string? ItemId { get; set; }
        public CollectionPageItem? Item { get; set; }
        private string SelectedTab { get; set; } = "overview";

        protected override async Task OnInitializedAsync()
        {
            Item = await CreateCollectionPageItem();

            await base.OnInitializedAsync();
        }

        private async Task<CollectionPageItem?> CreateCollectionPageItem()
        {
            if (!long.TryParse(ItemId, out long itemId))
            {
                _logger.LogError("Item Id could not be parse. {ItemId}", ItemId);
                return null;
            }

            var thingRequest = new ThingRequest
            {
                Id = new() { itemId },
                Stats = true
            };

            var thingResponse = await _thingHandler.GetThing(thingRequest);
            var thing = thingResponse.Item.Things.FirstOrDefault();
            var collectionItem = _appState.Collection?.Items.FirstOrDefault(x => x.Id == itemId);

            return new CollectionPageItem(collectionItem, thing);
        }

        private Task OnSelectedTabChanged(string name)
        {
            SelectedTab = name;
            return Task.CompletedTask;
        }
    }
}
