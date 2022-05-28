using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Serilog;

namespace Bgg.Net.Common.RequestHandlers.Users
{
    /// <summary>
    /// Handles User requests to the BGG API.
    /// </summary>
    public class UserHandler : RequestHandler, IUserHandler
    {
        public UserHandler(IBggDeserializer deserializer, ILogger logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory)
            : base(deserializer, logger, httpClient, validatorFactory)
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

        /// <inheritdoc/>
        public async Task<BggResult<User>> GetUserExtensible(Extension extension)
        {
            return await GetResourceExtensible<User>("user", Constants.SupportedUserQueryParameters, extension);
        }
    }
}
