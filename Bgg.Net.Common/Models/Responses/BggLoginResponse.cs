namespace Bgg.Net.Common.Models.Responses
{
    /// <summary>
    /// Represents a login response from the Bgg Api.
    /// </summary>
    public class BggLoginResponse
    {
        public string UserName
        {
            get
            {
                if (RawValues.TryGetValue("bggusername", out string value))
                {
                    return value;
                }

                return null;
            }
        }

        public string Password
        {
            get
            {
                if (RawValues.TryGetValue("bggpassword", out string value))
                {
                    return value;
                }

                return null;
            }
        }

        public string SessionId
        {
            get
            {
                if (RawValues.TryGetValue("SessionID", out string value))
                {
                    return value;
                }

                return null;
            }
        }

        public DateTime? Expiration
        {
            get
            {
                if (RawValues.TryGetValue("expires", out string value))
                {
                    return DateTime.Parse(value);
                }

                return null;
            }
        }

        /// <summary>
        /// The raw response values as key value pairs.
        /// </summary>
        public Dictionary<string, string> RawValues { get; private set; }

        public BggLoginResponse(Dictionary<string, string> values)
        {
            RawValues = values;
        }
    }
}
