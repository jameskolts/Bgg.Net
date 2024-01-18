using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Guilds
{
    /// <summary>
    /// Handles guild requests to the Bgg API.
    /// </summary>
    public class GuildHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder) 
        : RequestHandler(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder), IGuildHandler
    {

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuild(GuildRequest request)
        {
            return await GetResourceFromRequestObject<Guild>("guild", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuildById(long id)
        {
            var request = new GuildRequest
            {
                Id = id
            };

            return await GetResourceFromRequestObject<Guild>("guild", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<Guild>> GetGuildByIdWithMembers(long id, SortType sortType = SortType.UserName, int page = 1)
        {
            var request = new GuildRequest
            {
                Id = id,
                Members = true,
                Sort = sortType.ToString(),
                Page = page
            };

            return await GetResourceFromRequestObject<Guild>("guild", request);
        }
    }
}
