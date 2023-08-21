using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class BggLoginRequest
    {
        [JsonProperty("credentials")]
        public Credentials Credentials { get; set; }

        public BggLoginRequest() { }

        public BggLoginRequest(string username, string password)
        {
            Credentials = new(username, password);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
