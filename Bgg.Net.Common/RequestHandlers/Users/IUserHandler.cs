using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.RequestHandlers.Users
{
    /// <summary>
    /// Public interface for user Queries.
    /// </summary>
    public interface IUserHandler
    {
        /// <summary>
        /// Gets a user by name.
        /// </summary>
        /// <param name="name">The name of the user to retrieve.</param>
        /// <returns>A <see cref="BggResult{T}"/> containing the <see cref="User"/>.</returns>
        Task<BggResult<User>> GetUserByName(string name);

        /// <summary>
        /// Gets a collection by the parameters provided in the request.
        /// </summary>
        /// <param name="request">The request to query.</param>
        /// <returns>A <see cref="BggResult{T}"/> where T is a <see cref="User"/>.</returns>
        Task<BggResult<User>> GetUser(UserRequest request);
    }
}
