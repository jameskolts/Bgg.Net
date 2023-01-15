using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Components
{
    public partial class ForumComponent
    {
        [Parameter]
        public long Id { get; set; }
        [Parameter]
        public string Type { get; set; } = string.Empty;

        public ForumList? ForumList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ForumList = await GetForumList();

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

            var item = (await _bggClient.GetForumList(forumListRequest)).Item;

            return item;
        }
    }
}
