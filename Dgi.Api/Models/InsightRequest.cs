using Bgg.Net.Common.Models;
using Dgi.Api.Types;

namespace Dgi.Api.Models
{
    public class InsightRequest
    {
        public Collection Collection { get; set; }

        public InsightRequestType RequestType { get; set; }
    }
}
