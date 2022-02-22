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
    public class ForumListHandler : IForumListHandler
    {
        private readonly IHttpClient _client;
        private readonly ILogger _logger;
        private readonly IForumListDeserializer _deserializer;

        /// <summary>
        /// Creates an instance of <see cref="ForumListHandler"/>.
        /// </summary>
        /// <param name="httpClient">The httpClient.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="deserializer">The deserializer.</param>
        public ForumListHandler(IHttpClient httpClient, ILogger logger, IForumListDeserializer deserializer)
        {
            _client = httpClient;
            _logger = logger;
            _deserializer = deserializer;
        }

        public async Task<BggResult<ForumList>> GetForumListByIdAndType(long id, ForumListType type)
        {
            _logger.Information("GetForumListByIdAndType : {id}, {type}", id, type);

            var queryString = $"forumlist?id={id}&type={type.ToString().ToLower()}";

            var httpResponseMessage = await _client.GetAsync(queryString);

            return await BuildBggResult(httpResponseMessage);
        }

        private async Task<BggResult<ForumList>> BuildBggResult(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var bggResult = new BggResult<ForumList>();

            try
            {
                bggResult.Items.Add(_deserializer.Deserialize(responseString));
            }
            catch (Exception exception)
            {
                var errorString = $"Error during deserialization. {exception.Message}";
                _logger.Error(exception, errorString);
                bggResult.Errors.Add(errorString);
            }

            bggResult.IsSuccessful = httpResponse.IsSuccessStatusCode && !bggResult.Errors.Any();
            bggResult.HttpResponseCode = httpResponse.StatusCode;

            return bggResult;
        }
    }
}
