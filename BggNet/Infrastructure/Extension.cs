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
        public Dictionary<string, List<int>> Value { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
