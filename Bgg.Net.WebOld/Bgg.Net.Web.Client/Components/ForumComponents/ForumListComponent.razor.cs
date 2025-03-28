﻿using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Microsoft.AspNetCore.Components;

namespace Bgg.Net.Web.Client.Components.ForumComponents
{
    public partial class ForumListComponent
    {
        [Parameter]
        public long Id { get; set; }
        [Parameter]
        public string Type { get; set; } = string.Empty;
        public ForumList? ForumList { get; set; }

        private ForumComponent _forumComponent = new();

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

            return (await _forumClient.GetForumList(forumListRequest)).Item;
        }

        private async Task UpdateForumComponent(long forumId)
        {
            await _forumComponent.LoadForum(forumId);
        }

        private void LoadInitialForum()
        {
            var initialForumId = ForumList?.Forums
                .Where(x => x.Title == "General")
                .Select(x => x.Id)
                .FirstOrDefault();

            if (initialForumId.HasValue)
            {
                _forumComponent?.LoadForum(initialForumId.Value);
            }
        }
    }
}
