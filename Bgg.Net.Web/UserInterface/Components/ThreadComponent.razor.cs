using Bgg.Net.Common.Models;
using Microsoft.AspNetCore.Components;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Web.UserInterface.Components
{
    public partial class ThreadComponent
    {
        [Parameter]
        public Thread Thread { get; set; }

        private string GetPostTime(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
