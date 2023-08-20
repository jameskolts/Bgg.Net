using Bgg.Net.Common.Models.Responses;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Adds the given login cookie to the contents headers.
        /// </summary>
        /// <param name="content">The content to add the login information to.</param>
        /// <param name="cookie">The cookie to add.</param>
        /// <returns>The <see cref="StringContent"/> with the header properly formatted.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static StringContent AddLoginCookie(this StringContent content, BggLoginCookie cookie)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (cookie == null)
            {
                throw new ArgumentNullException(nameof(cookie));
            }

            content.Headers.Add("cookie", string.Join("; ", cookie.UserName, cookie.Password, cookie.SessionId));

            return content;
        }
    }
}
