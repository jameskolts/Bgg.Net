using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    /// <summary>
    /// Handles ForumList requests to the BGG API.
    /// </summary>
    /// <remarks>
    /// Creates an instance of <see cref="ForumListHandler"/>.
    /// </remarks>
    /// <param name="httpClient">The httpClient.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="deserializer">The deserializer.</param>
    public class ForumListHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder) 
        : RequestHandler(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder), IForumListHandler
    {

        /// <inheritdoc/>
        public async Task<BggResult<ForumList>> GetForumList(ForumListRequest request)
        {
            return await GetResourceFromRequestObject<ForumList>("forumlist", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ForumList>> GetForumListByIdAndType(long id, ItemType type)
        {
            var request = new ForumListRequest
            {
                Id = id,
                Type = type.ToString()
            };

            return await GetResourceFromRequestObject<ForumList>("forumlist", request);
        }
    }
}
