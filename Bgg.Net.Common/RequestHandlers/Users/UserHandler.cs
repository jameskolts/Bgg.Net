using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Infrastructure.Http;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;

namespace Bgg.Net.Common.RequestHandlers.Users
{
    /// <summary>
    /// Handles User requests to the BGG API.
    /// </summary>
    public class UserHandler : RequestHandler, IUserHandler
    {
        public UserHandler(IDeserializerFactory deserializerFactory, ILogger<RequestHandler> logger, IHttpClient httpClient, IRequestValidatorFactory validatorFactory, IQueryBuilder queryBuilder)
            : base(deserializerFactory, logger, httpClient, validatorFactory, queryBuilder)
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
            var request = new UserRequest(name);

            return await GetResourceFromRequestObject<User>("user", request);
        }
    }
}
