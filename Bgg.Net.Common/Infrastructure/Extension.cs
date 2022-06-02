using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Infrastructure
{
    /// <summary>
    /// Represents an extension to allow for extensible additions to queries and searches
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Extension
    {
        /// <summary>
        /// The value of the extension as a key value pair.
        /// </summary>
        public Dictionary<string, List<string>> Values { get; internal set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Adds a Key Value Pair to the extensions value.  
        /// The key and values will be made lowercase.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="values">The value to add.</param>
        public void AddValue(string key, List<string> values)
        {
            Values.Add(key.ToLower(), values.ConvertAll(v => v.ToLower()));
        }
    }
}
