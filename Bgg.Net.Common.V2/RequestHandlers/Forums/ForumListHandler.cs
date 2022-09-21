using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    /// <summary>
    /// Handles ForumList requests to the BGG API.
    /// </summary>
    public class ForumListHandler : RequestHandler, IForumListHandler
    {
        /// <summary>s
        /// Creates an instance of <see cref="ForumListHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ForumListHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<ForumList>> GetForumList(ForumListRequest request)
        {
            return await GetResourceFromRequestObject<ForumList>("forumlist", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<ForumList>> GetForumListByIdAndType(long id, ItemType type)
        {
            _logger.Information("GetForumListByIdAndType : {id}, {type}", id, type);

            var request = new ForumListRequest
            {
                Id = id,
                Type = type
            };

            return await GetResourceFromRequestObject<ForumList>("forumlist", request);
        }
    }
}
