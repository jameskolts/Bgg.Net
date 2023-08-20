using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// The base clase for BggRequests to the XmlApi2.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BggRequest
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
