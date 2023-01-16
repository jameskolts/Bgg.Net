using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Web.Components
{
    public partial class ForumComponent
    {
        [Parameter]
        public Action? FirstRenderAction { get; set; }

        public Forum? Forum { get; set; }
        public Thread? Thread { get; set; }

        private ThreadComponent? _threadComponent = new();
        private bool isLoading = false;
        private bool showForum = true;
        private bool showThreads = false;

        private bool isTrue = true;
        private bool isFalse = false;

        public async Task LoadForum(long forumId)
        {
            isLoading = true;

            var forumRequest = new ForumRequest
            {
                Id = forumId
            };

            Forum = (await _bggClient.GetForum(forumRequest)).Item;

            isLoading = false;
            showForum = true;
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

            var threadResult = await _bggClient.GetThread(new ThreadRequest(threadId));

            if (threadResult.IsSuccessful)
            {
                Thread = threadResult.Item;
            }

            isLoading = false;
            showForum = false;
            showThreads = true;
        }

        private string GetDaysApart(DateTime start, DateTime end)
        {
            var daysApart = (start - end).Days;

            var daysApartString = $"{daysApart} day";
            daysApartString += daysApart > 1 ? "s ago" : " ago";
            return daysApartString;
        }
    }
}
