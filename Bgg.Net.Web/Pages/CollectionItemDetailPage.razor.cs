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

        protected override async Task OnInitializedAsync()
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

            Item = new CollectionPageItem(collectionItem, thing);

            await base.OnInitializedAsync();
        }

    }
}
