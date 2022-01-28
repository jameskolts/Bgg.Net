using Bgg.Net.Common.Models;
using System.Net;

namespace Bgg.Net.Common.Infrastructure
{
    public class BggResult<T>
        where T : BggBase
    {
        public List<T> Items { get; set; } = new List<T>();

        public List<string> Errors { get; set; } = new List<string>();

        public bool IsSuccessful { get; set; }

        public HttpStatusCode HttpResponseCode { get; set; }
    }
}
