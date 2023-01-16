using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Web.Components
{
    public partial class ThreadComponent
    {
        [Parameter]
        public Thread Thread { get; set; }
    }
}
