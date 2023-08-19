using System.Net.Http.Headers;

namespace Bgg.Net.Common.Models.Responses
{
    /// <summary>
    /// Represents a login response from the Bgg Api.
    /// </summary>
    public class BggLoginCookie
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string SessionId { get; set; }

        public BggLoginCookie(HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues("set-cookie", out var values))
            {

                foreach (var value in values)
                {
                    var splitValue = value.Split('=');

                    if (value.StartsWith("bggusername") && !splitValue[1].StartsWith("deleted"))
                    {
                        UserName = value.Split(';').First();
                    }
                    else if (value.StartsWith("bggpassword") && !splitValue[1].StartsWith("deleted"))
                    {
                        Password = value.Split(';').First();
                    }
                    else if (value.StartsWith("SessionID"))
                    {
                        SessionId = value.Split(';').First();
                    }
                }
            }
            else
            {
                throw new ArgumentException("Response header did not contain valid cookies");
            }
        }
    }
}
