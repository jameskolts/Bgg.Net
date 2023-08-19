using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Responses;

namespace Bgg.Net.Web.Models
{
    public class AppState
    {
        public Collection? Collection { get; set; }

        public BggLoginResponse? BggUser { get; set; }
    }
}
