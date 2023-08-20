using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    [ExcludeFromCodeCoverage]
    public class Credentials
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        public Credentials(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
