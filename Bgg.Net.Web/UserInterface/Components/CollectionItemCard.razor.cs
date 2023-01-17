using Bgg.Net.Web.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.UserInterface.Components
{
    public partial class CollectionItemCard
    {
        [Parameter]
        public CollectionPageItem? Item { get; set; }
    }
}
