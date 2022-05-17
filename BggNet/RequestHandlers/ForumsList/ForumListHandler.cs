using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Bgg.Net.Common.Http;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using Bgg.Net.Common.Infrastructure.Extensions;

namespace Bgg.Net.Common.RequestHandlers.ForumsList
{   
    /// <summary>
    /// Handles ForumList requests to the BGG API.
    /// </summary>
    public class ForumListHandler : RequestHandler, IForumListHandler
    {
        /// <summary>
        /// Creates an instance of <see cref="ForumListHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ForumListHandler(IHttpClient httpClient, ILogger logger, IBggDeserializer deserializer)
            : base(deserializer, logger, httpClient)
        {
        }

        public async Task<BggResult<ForumList>> GetForumListByIdAndType(long id, ForumListType type)
        {
            _logger.Information("GetForumListByIdAndType : {id}, {type}", id, type);

            var queryString = $"forumlist?id={id}&type={type.ToString().ToLower()}";

            var httpResponseMessage = await _httpClient.GetAsync(queryString);

            return await BuildBggResult<ForumList>(httpResponseMessage);
        }
    }
}
