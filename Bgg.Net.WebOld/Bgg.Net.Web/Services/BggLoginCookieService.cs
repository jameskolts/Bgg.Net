using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Models.Responses;
using Dgi.Client.Clients.Bgg;

namespace Bgg.Net.Web.Services
{
    public class BggLoginCookieService : IBggLoginCookieService
    {
        private readonly ILoginClient _loginClient;

        private BggLoginCookie? _loginCookie;
        public async Task<BggLoginCookie> GetLoginCookie(string username, string password)
        {           
            if (_loginCookie == null ||
                _loginCookie.Expires?.ToUniversalTime() <= DateTime.UtcNow ||
                _loginCookie.UserName != username)
            {
                var loginResponse = await _loginClient.Login(new Credentials(username, password));

                if (loginResponse.IsSuccessful)
                {
                    _loginCookie = loginResponse.Item;
                }
            }

            return _loginCookie!;
        }

        public BggLoginCookieService(ILoginClient loginClient)
        {
            _loginClient = loginClient;
        }
    }
}
