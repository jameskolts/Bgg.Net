using Bgg.Net.Common.Models.Responses;

namespace Bgg.Net.Web.Services
{
    public interface IBggLoginCookieService
    {
        /// <summary>
        /// Retrieves a BGG login cookie for the given user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A <see cref="BggLoginCookie"/> for the user.</returns>
        Task<BggLoginCookie> GetLoginCookie(string username, string password);
    }
}
