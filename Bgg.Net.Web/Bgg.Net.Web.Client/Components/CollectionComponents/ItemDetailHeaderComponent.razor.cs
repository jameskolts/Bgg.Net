using Bgg.Net.Web.Client.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Client.Components.CollectionComponents
{
    public partial class ItemDetailHeaderComponent
    {
        [Parameter]
        public CollectionPageItem? Item { get; set; }

        private static string CreateToolTipText(IEnumerable<string> strings)
        {
            if (strings == null || !strings.Any())
            {
                return string.Empty;
            }

            return $"+ {strings.Count()} more";
        }
    }
}
