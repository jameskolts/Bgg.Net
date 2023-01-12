using Bgg.Net.Web.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Components
{
    public partial class CollectionItemDetailHeaderComponent
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
