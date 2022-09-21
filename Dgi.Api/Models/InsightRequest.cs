using Bgg.Net.Common.Models;

namespace Dgi.Api.Models
{
    public class InsightRequest
    {
        public BggBase? BggItem { get; set; }

        public string? RequestType { get; set; }
    }
}
