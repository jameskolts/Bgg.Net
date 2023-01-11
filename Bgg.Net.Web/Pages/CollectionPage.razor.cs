namespace Bgg.Net.Web.Pages
{
    public partial class CollectionPage
    {
        public Common.Models.Collection? Collection { get; set; }

        private async Task GetCollection()
        {
            var result = await _collectionHandler.GetCollectionByUserName("JusticiarIV");

            Collection = result.Item;
        }
    }
}
