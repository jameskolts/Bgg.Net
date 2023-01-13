using Microsoft.AspNetCore.Components;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Models;

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
            if (!Enum.TryParse(Type, out ItemType itemType))
            {
                itemType = ItemType.Thing;
            }

            return (await _forumListHandler.GetForumListByIdAndType(Id, itemType)).Item;
        }
    }
}
