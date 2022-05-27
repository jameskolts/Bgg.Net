using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models.Requests;
using Serilog;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Common.RequestHandlers.Threads
{
    /// <summary>
    /// Handles Thread requests to the BGG API
    /// </summary>
    public class ThreadHandler : RequestHandler, IThreadHandler
    {
        public ThreadHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient)
            : base(deserializer, logger, httpClient)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Thread>> GetThread(ThreadRequest request)
        {
            return await GetResourceFromRequestObject<Thread>("thread", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Thread>> GetThreadById(int id)
        {
            _logger.Information("GetThreadById : {id}", id);

            var httpResponseMessage = await _httpClient.GetAsync($"thread?id={id}");

            return await BuildBggResult<Thread>(httpResponseMessage);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Thread>> GetThreadExtensible(Extension extension)
        {
            return await GetResourceExtensible<Thread>("thread", Constants.SupportedThreadQueryParameters, extension);
        }
    }
}
