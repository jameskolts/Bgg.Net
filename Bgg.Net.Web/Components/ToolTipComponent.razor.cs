using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Components
{
    public partial class ToolTipComponent
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Text { get; set; }
    }

}
