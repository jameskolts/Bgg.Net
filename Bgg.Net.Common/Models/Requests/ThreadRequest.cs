namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a Thread to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    public class ThreadRequest : BggRequest
    {
        /// <summary>
        /// Specifies the id of the thread to retrieve.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Filters the results so that only articles with an equal or higher id than NNN will be returned.
        /// </summary>
        public int? MinArticleId { get; set; }

        /// <summary>
        /// Filters the results so that only articles on the specified dateTime or later will be returned.
        /// </summary>
        /// <remarks>Should be in the format "YYYY-mm-dd or YYYY-mm-dd HH:MM:SS</remarks>
        public string MinArticleDateTime { get; set; }

        /// <summary>
        /// Limits the number of articles returned to no more than NNN.
        /// </summary>
        public int? Count { get; set; }

        public ThreadRequest(long id)
        {
            Id = id;
        }
    }
}
