using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Bgg.Net.Common.RequestHandlers.Login
{
    public class BggLoginHandler
    {
        private readonly IHttpClient _httpClient;

        public BggLoginHandler(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BggLoginResponse> Login(string username, string password)
        {
            var loginRequest = new BggLoginRequest(username, password);
            var requestContent = new StringContent(loginRequest.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Constants.BggLoginRoute, requestContent);

            return new BggLoginResponse(BuildCookieDictionary(response.Headers));
        }

        private static Dictionary<string, string> BuildCookieDictionary(HttpResponseHeaders responseHeaders)
        {
            var cookieDictionary = new Dictionary<string, string>();

            if (responseHeaders.TryGetValues("set-cookie", out var values))
            {
                var splitstrings = values
                    .Select(x => x.Split(';'));

                foreach (var split in splitstrings)
                {
                    foreach (var pairing in split)
                    {
                        var pair = pairing.Split('=');
                        if (pair.Length == 2 &&
                            pair[1] != "deleted" &&
                            !cookieDictionary.ContainsKey(pair[0]))
                        {
                            cookieDictionary.Add(pair[0], pair[1]);
                        }
                    }
                }
            }

            return cookieDictionary;
        }
    }
}
