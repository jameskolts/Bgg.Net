﻿using Bgg.Net.Common.Infrastructure;
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
        /// <returns>A <see cref="BggLoginCookie"/> that contains the cookie information that should be used for requests that require log in.</returns>
        /// <exception cref="ArgumentNullException"/>
        Task<BggResult<BggLoginCookie>> Login(string username, string password);
    }
}
