using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Web.Models;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;

namespace Bgg.Net.Web.Pages
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

        private async Task<CollectionPageItem> CreateCollectionPageItem()
        {
            var itemId = long.Parse(ItemId);
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
            selectedTab = name;
            return Task.CompletedTask;
        }
    }
}
