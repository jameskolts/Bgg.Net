using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Components
{
    public partial class ForumComponent
    {
        [Parameter]
        public Action? FirstRenderAction { get; set; }

        public Forum? Forum { get; set; }

        private bool isLoading = false;

        public async Task LoadForum(long forumId)
        {
            isLoading = true;

            var forumRequest = new ForumRequest
            {
                Id = forumId
            };

            Forum = (await _bggClient.GetForum(forumRequest)).Item;
            isLoading = false;
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

        private string GetDaysApart(DateTime start, DateTime end)
        {
            var daysApart = (start - end).Days;

            var daysApartString = $"{daysApart} day";
            daysApartString += daysApart > 1 ? "s ago" : " ago";
            return daysApartString;
        }
    }
}
