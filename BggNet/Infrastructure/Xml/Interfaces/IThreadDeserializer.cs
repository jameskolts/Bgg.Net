using Bgg.Net.Common.Models;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Common.Infrastructure.Xml.Interfaces
{
    public interface IThreadDeserializer
    {
        /// <summary>
        /// Deserializes the given xml into a list of threads.
        /// </summary>
        /// <param name="xml">The xml to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="Thread"/>.</returns>
        List<Thread> DeserializeThreads(string xml);

        /// <summary>
        /// Deserializes the given xml into a list of ThreadSummries.
        /// </summary>
        /// <param name="xml">The xml to deserialize.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="ThreadSummary"/>.</returns>
        List<ThreadSummary> DeserializeThreadSummaries(string xml);
    }
}
