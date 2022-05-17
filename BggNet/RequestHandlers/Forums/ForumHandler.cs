using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Models;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Forums
{
    public class ForumHandler : RequestHandler, IForumHandler
    {
        /// <summary>
        /// Creates an instance of <see cref="ForumListHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ForumHandler(IHttpClient httpClient, ILogger logger, IBggDeserializer deserializer)
            : base(deserializer, logger, httpClient)
        {
        }

        public async Task<BggResult<Forum>> GetForumById(long id)
        {
            _logger.Information("GetForumById : {id}", id);

            var queryString = $"forum?id={id}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<Forum>(httpResponseMessage);
        }
    }
}
