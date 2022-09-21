namespace Dgi.Api.Models
{
    public class CollectionInsight : Insight
    {
        /// <summary>
        /// The total number of games contained in the collection.
        /// </summary>
        public int TotalGames { get; set; }

        public string MostPlayedGame { get; set; }

        public string FavoriteGenre { get; set; }
    }
}
