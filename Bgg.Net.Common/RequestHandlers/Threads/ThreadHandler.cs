using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using Thread = Bgg.Net.Common.Models.Bgg.Thread;

namespace Bgg.Net.Common.RequestHandlers.Threads
{
    /// <summary>
    /// Handles Thread requests to the BGG API
    /// </summary>
    public class ThreadHandler : RequestHandler, IThreadHandler
    {
        public ThreadHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
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
            var request = new ThreadRequest(id);

            return await GetResourceFromRequestObject<Thread>("thread", request);
        }
    }
}
