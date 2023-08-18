using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Web.UserInterface.Components
{
    public partial class ThreadComponent
    {
        [Parameter, EditorRequired]
        public Thread Thread { get; set; } = new();

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("methods.formatQuotes");
            }

            base.OnAfterRender(firstRender);
        }

        private static RenderFragment RenderMessageBody(string message)
        {
            var fragment = new RenderFragment(x => 
                { 
                    x.AddMarkupContent(0, message);
                });

            return fragment;
        }

        private static string FormatPostDate(string postDate)
        {
            if (!DateTime.TryParse(postDate, out var date))
            {
                throw new ArgumentException("Invalid postDate");
            }

            return date.ToLocalTime().ToString();
        }
    }
}
