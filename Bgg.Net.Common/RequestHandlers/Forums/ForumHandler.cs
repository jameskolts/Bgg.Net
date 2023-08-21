using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    public class ForumHandler : RequestHandler, IForumHandler
    {
        /// <summary>
        /// Creates an instance of <see cref="ForumHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ForumHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<Forum>> GetForum(ForumRequest request)
        {
            return await GetResourceFromRequestObject<Forum>("forum", request);
        }

        public async Task<BggResult<Forum>> GetForumById(long id)
        {
            var request = new ForumRequest
            {
                Id = id
            };

            return await GetResourceFromRequestObject<Forum>("forum", request);
        }

        public async Task<BggResult<Forum>> GetForumByIdAndPage(long id, uint page)
        {
            var request = new ForumRequest
            {
                Id = id,
                Page = page
            };

            return await GetResourceFromRequestObject<Forum>("forum", request);
        }
    }
}