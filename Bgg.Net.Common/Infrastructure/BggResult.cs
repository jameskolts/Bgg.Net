using Bgg.Net.Common.Models;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Bgg.Net.Common.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class BggResult<T>
        where T : BggBase
    {
        public T Item { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public bool IsSuccessful { get; set; }

        public HttpStatusCode? HttpResponseCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
