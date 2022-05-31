using Newtonsoft.Json;

namespace Bgg.Net.Common.Infrastructure
{
    /// <summary>
    /// Represents an extension to allow for extensible additions to queries and searches
    /// </summary>
    public class Extension
    {
        /// <summary>
        /// The value of the extension as a key value pair.
        /// </summary>
        public Dictionary<string, List<string>> Value { get; set; } = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Adds a Key Value Pair to the extensions value.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add.</param>
        public void AddValue(string key, List<string> value)
        {
            Value.Add(key, value);
        }
    }
}
