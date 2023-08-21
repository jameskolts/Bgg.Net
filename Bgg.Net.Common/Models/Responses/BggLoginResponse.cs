using System.Net.Http.Headers;

namespace Bgg.Net.Common.Models.Responses
{
    /// <summary>
    /// Represents a login response from the Bgg Api.
    /// </summary>
    public class BggLoginCookie
    {
        public string UserName { get; set; }

        public string UserNameCookie { get; set; }

        public string PasswordCookie { get; set; }

        public string SessionIdCookie { get; set; }

        public DateTime? Expires { get; set; }

        public BggLoginCookie() { }

        public BggLoginCookie(HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues("set-cookie", out var values))
            {

                foreach (var value in values)
                {
                    var splitValue = value.Split('=');

                    if (value.StartsWith("bggusername") && !splitValue[1].StartsWith("deleted"))
                    {
                        var keyValuePairs = value.Split(';');
                        UserNameCookie = keyValuePairs.First();
                        UserName = UserNameCookie.Split('=')[1];
                        Expires = DateTime.Parse(keyValuePairs[1].Split('=')[1]);
                    }
                    else if (value.StartsWith("bggpassword") && !splitValue[1].StartsWith("deleted"))
                    {
                        PasswordCookie = value.Split(';').First();
                    }
                    else if (value.StartsWith("SessionID"))
                    {
                        SessionIdCookie = value.Split(';').First();
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
