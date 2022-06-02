using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Users
{
    /// <summary>
    /// Handles User requests to the BGG API.
    /// </summary>
    public class UserHandler : RequestHandler, IUserHandler
    {
        public UserHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializer, logger, httpClient, validatorFactory, queryBuilder)
        {
        }

        /// <inheritdoc/>
        public async Task<BggResult<User>> GetUser(UserRequest request)
        {
            return await GetResourceFromRequestObject<User>("user", request);
        }

        /// <inheritdoc/>
        public async Task<BggResult<User>> GetUserByName(string name)
        {
            _logger.Information("GetUserByName : {name}", name);

            var httpResponseMessage = await _httpClient.GetAsync($"user?name={name}");

            return await BuildBggResult<User>(httpResponseMessage);
        }
    }
}
