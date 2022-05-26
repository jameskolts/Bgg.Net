using System.Collections.ObjectModel;

namespace Bgg.Net.Common
{
    public class Constants
    {
        public const string BGG_PATH = "https://www.boardgamegeek.com/xmlapi2/";
        public const string RPGGEEK_PATH = "https://www.rpggeek.com/xmlapi2/";
        public const string VIDEOGAMEGEEK_PATH = "https://www.videogamegeek.com/xmlapi2/";

        public static ReadOnlyCollection<string> SupportedThingQueryParameters { get; } = new ReadOnlyCollection<string>(
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

        public static ReadOnlyCollection<string> SupportedFamilyQueryParameters { get; } = new ReadOnlyCollection<string>(
            new string[]
            {
                "id",
                "type"
            });

        public static ReadOnlyCollection<string> SupportedThreadQueryParameters { get; } = new ReadOnlyCollection<string>(
            new string[]
            {
                "id",
                "minarticleid",
                "minarticledate",
                "count"
            });

        public static ReadOnlyCollection<string> SupportedUserQueryParameters { get; } = new ReadOnlyCollection<string>(
            new string[]
            {
                "name",
                "buddies",
                "guilds",
                "hot",
                "top",
                "domain",
                "page"
            });

        public static ReadOnlyCollection<string> SupportedGuildParameters { get; } = new ReadOnlyCollection<string>(
           new string[]
           {
                "id",
                "members",
                "sort",
                "page"
           });

        public static ReadOnlyCollection<string> SupportedPlaysParameters { get; } = new ReadOnlyCollection<string>(
           new string[]
           {
                "id",
                "username",
                "type",
                "mindate",
                "maxdate",
                "subtype",
                "page"
           });

        public static ReadOnlyCollection<string> SupportedCollectionParameters { get; } = new ReadOnlyCollection<string>(
           new string[]
           {
                "username",
                "version",
                "subtype",
                "excludesubtype",
                "id",
                "brief",
                "stats",
                "own",
                "rated",
                "played",
                "comment",
                "trade",
                "want",
                "wishlist",
                "wishlistpriority",
                "preordered",
                "wanttoplay",
                "wanttobuy",
                "prevowned",
                "hasparts",
                "wantparts",
                "minrating",
                "rating",
                "minbggrating",
                "bggrating",
                "minplays",
                "maxplays",
                "showprivate",
                "collid",
                "modifiedsince",
           });

        public static ReadOnlyCollection<string> SupportedHotItemParameters { get; } = new ReadOnlyCollection<string>(
           new string[]
           {
                "type",
           });

        public static ReadOnlyCollection<string> SupportedSearchParameters { get; } = new ReadOnlyCollection<string>(
           new string[]
           {
                "query",
                "type",
                "exact"
           });
    }
}
