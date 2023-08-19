using Bgg.Net.Common.Models.Responses;

namespace Bgg.Net.Common.RequestHandlers.Login
{ 
    public interface IBggLoginHandler
    {
        /// <summary>
        /// Logs a given user into the Bgg Api.
        /// </summary>
        /// <param name="username">The user to log in.</param>
        /// <param name="password">the password of the user.</param>
        /// <returns>A <see cref="BggLoginResponse"/> that contains the cookie information that should be used for requests that require log in.</returns>
        Task<BggLoginResponse> Login(string username, string password);
    }
}
