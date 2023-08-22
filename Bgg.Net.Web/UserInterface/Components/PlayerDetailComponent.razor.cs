using Bgg.Net.Common.Models.Bgg;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.UserInterface.Components
{
    public partial class PlayerDetailComponent
    {
        [Parameter]
        [EditorRequired]
        public Player Player { get; set; }

        public PlayerDetailComponent()
        {
            Player = new();
        }
    }
}
