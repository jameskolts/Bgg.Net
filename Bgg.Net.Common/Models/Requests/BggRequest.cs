using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// The base clase for BggRequests to the XmlApi2.
    /// </summary>
    public class BggRequest
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
