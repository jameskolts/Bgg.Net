using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;
using Thread = Bgg.Net.Common.Models.Bgg.Thread;

namespace Bgg.Net.Web.Client.Components.ForumComponents
{
    public partial class ForumComponent
    {
        [Parameter]
        public Action? FirstRenderAction { get; set; }

        public Forum? Forum { get; set; }
        public Thread? Thread { get; set; }

        private bool isLoading = false;
        private bool showForums = true;
        private bool showThreads = false;

        public async Task LoadForum(long forumId)
        {
            isLoading = true;

            var forumRequest = new ForumRequest
            {
                Id = forumId
            };

            Forum = (await _forumClient.GetForum(forumRequest)).Item;

            isLoading = false;
            showForums = true;
            showThreads = false;
            StateHasChanged();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                FirstRenderAction?.Invoke();
            }
        }

        public async Task LoadThreads(long threadId)
        {
            isLoading = true;

            var threadResult = await _threadClient.GetThread(new ThreadRequest(threadId));

            if (threadResult.IsSuccessful)
            {
                Thread = threadResult.Item;
            }

            isLoading = false;
            showForums = false;
            showThreads = true;
        }

        private static string GetDaysApart(DateTime start, DateTime end)
        {
            var daysApart = (start - end).Days;

            var daysApartString = $"{daysApart} day";
            daysApartString += daysApart > 1 ? "s ago" : " ago";
            return daysApartString;
        }
    }
}
