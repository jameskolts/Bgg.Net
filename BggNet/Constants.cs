using System.Collections.ObjectModel;

namespace Bgg.Net.Common
{
    public class Constants
    {
        public const string BGG_PATH = "https://www.boardgamegeek.com/xmlapi2/";
        public const string RPGGEEK_PATH = "https://www.rpggeek.com/xmlapi2/";
        public const string VIDEOGAMEGEEK_PATH = "https://www.videogamegeek.com/xmlapi2/";

        public static ReadOnlyCollection<string> SupportedQueryParameters { get; } = new ReadOnlyCollection<string>(
            new string[]
            {
                "id",
                "type",
                "versions",
                "videos",
                "stats",
                "marketplace",
                "comments",
                "ratingcomments",
                "page",
                "pagesize" 
            });
    }
}
