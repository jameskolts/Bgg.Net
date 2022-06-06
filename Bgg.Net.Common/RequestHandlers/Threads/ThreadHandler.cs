using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Serilog;
using Thread = Bgg.Net.Common.Models.Thread;

namespace Bgg.Net.Common.RequestHandlers.Threads
{
    /// <summary>
    /// Handles Thread requests to the BGG API
    /// </summary>
    public class ThreadHandler : RequestHandler, IThreadHandler
    {
        public ThreadHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
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

            var request = new ThreadRequest(id);

            return await GetResourceFromRequestObject<Thread>("thread", request);
        }
    }
}
