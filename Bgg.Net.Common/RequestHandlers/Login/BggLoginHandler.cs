using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Bgg.Net.Common.RequestHandlers.Login
{
    public class BggLoginHandler : IBggLoginHandler
    {
        private readonly IHttpClient _httpClient;
        private readonly ILogger<BggLoginHandler> _logger;

        public BggLoginHandler(IHttpClient httpClient, ILogger<BggLoginHandler> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<BggResult<BggLoginCookie>> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var loginRequest = new BggLoginRequest(username, password);
            var requestContent = new StringContent(loginRequest.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Constants.BggLoginRoute, requestContent);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("BggLoginHandler: Response did not indicate success");
                return new BggResult<BggLoginCookie>
                {
                    IsSuccessful = false,
                    HttpResponseCode = response.StatusCode
                };
            }

            return new BggResult<BggLoginCookie>
            {
                IsSuccessful = true,
                HttpResponseCode = response.StatusCode,
                Item = new BggLoginCookie(response.Headers)
            };
        }
    }
}
