using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Serilog;

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
        public ForumHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory)
            : base(deserializer, logger, httpClient, validatorFactory)
        {
        }

        public async Task<BggResult<Forum>> GetForumById(long id)
        {
            _logger.Information("GetForumById : {id}", id);

            var queryString = $"forum?id={id}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<Forum>(httpResponseMessage);
        }

        public async Task<BggResult<Forum>> GetForumByIdAndPage(long id, int page)
        {
            _logger.Information("GetForumByIdAndPage : {id}, {page}", id, page);

            var queryString = $"forum?id={id}&page={page}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<Forum>(httpResponseMessage);
        }
    }
}
