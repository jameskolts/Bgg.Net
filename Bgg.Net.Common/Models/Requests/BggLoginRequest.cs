using Newtonsoft.Json;

namespace Bgg.Net.Common.Models.Requests
{
    public class BggLoginRequest
    {
        [JsonProperty("credentials")]
        public Credentials Credentials { get; set; }

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
