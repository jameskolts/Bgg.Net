using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Components
{
    public partial class ForumListComponent
    {
        [Parameter]
        public long Id { get; set; }
        [Parameter]
        public string Type { get; set; } = string.Empty;

        public ForumList? ForumList { get; set; }
        public Forum? Forum { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            ForumList = await GetForumList();

            var initialForumId = ForumList.Forums
                .Where(x => x.Title == "General")
                .Select(x => x.Id)
                .FirstOrDefault();
            await LoadForum(initialForumId);

            await base.OnInitializedAsync();
        }

        private async Task<ForumList> GetForumList()
        {
            //Todo: Best way to set type?  
            // Item type is "boardgame" but this request is looking for "thing" for board games from bgg.
            var forumListRequest = new ForumListRequest
            {
                Id = Id,
                Type = "thing"
            };

            return (await _bggClient.GetForumList(forumListRequest)).Item;
        }

        private async Task LoadForum(long forumId)
        {
            var forumRequest = new ForumRequest
            {
                Id = forumId
            };

            Forum = (await _bggClient.GetForum(forumRequest)).Item;
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
