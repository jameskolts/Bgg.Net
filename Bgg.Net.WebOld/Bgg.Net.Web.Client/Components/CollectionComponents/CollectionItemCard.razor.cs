using Bgg.Net.Web.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Client.Components.CollectionComponents
{
    public partial class CollectionItemCard
    {
        [Parameter]
        public CollectionPageItem? Item { get; set; }
    }
}
