using Bgg.Net.Common.Models.Bgg;

namespace Bgg.Net.Web.Client.Services
{
    /// <summary>
    /// Public interface for the DateTime service.
    /// </summary>
    public interface IDateTimeService
    {
        /// <summary>
        /// Given an article, returns a string indicating how long ago it occurred.
        /// </summary>
        /// <param name="article">The article to build the string for.</param>
        /// <returns>A string indicating how long ago it occurred. Eg: "2 days ago."</returns>
        string BuildTimeApartString(Article article);

        /// <summary>
        /// Given a ForumThread, returns a string indicating how long ago it occurred.
        /// </summary>
        /// <param name="thread">The thread to build the string for.</param>
        /// <returns>A string indicating how long ago it occurred. Eg: "2 days ago."</returns>
        string BuildTimeApartString(ForumThread thread);

        /// <summary>
        /// Given a dateTime, returns a string indicating how long ago it occurred.
        /// </summary>
        /// <param name="dateTime">The dateTime to build the string for.</param>
        /// <returns>A string indicating how long ago it occurred. Eg: "2 days ago."</returns>
        string BuildTimeApartString(DateTime dateTime);
    }
}
