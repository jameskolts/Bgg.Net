using Bgg.Net.Common.Types;
using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Models.Requests
{
    /// <summary>
    /// Represents a request for a collection to the BoardGameGeex Xml API2.
    /// Null properties will be excluded from the query.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionRequest : BggRequest
    {
        public CollectionRequest() { }

        public CollectionRequest(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// Name of the user to request the collection for.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Returns version info for each item in the collection.
        /// </summary>
        public bool? Version { get; set; }

        /// <summary>
        /// Specifies which collection you want to retrieve.
        /// </summary>
        public CollectionSubType? Subtype { get; set; }

        /// <summary>
        /// Specifies which subtype you want to exclude from the results.
        /// </summary>
        public CollectionSubType? ExcludeSubtype { get; set; }

        /// <summary>
        /// Filter collection to specifically listed item(s). NNN may be a comma-delimited list of item ids.
        /// </summary>
        public List<long> Id { get; set; } = new List<long>();

        /// <summary>
        /// Returns more abbreviated results.
        /// </summary>
        public bool? Brief { get; set; }

        /// <summary>
        /// Returns expanded rating/ranking info for the collection.
        /// </summary>
        public bool? Stats { get; set; }

        /// <summary>
        /// Filter for owned games. 
        /// Set to false to exclude these items so marked. Set to true for returning owned games and false for non-owned games.
        /// </summary>
        public bool? Own { get; set; }

        /// <summary>
        /// Filter for whether an item has been rated. 
        /// Set to 0 to exclude these items so marked. Set to 1 to include only these items so marked.
        /// </summary>
        public bool? Rated { get; set; }

        /// <summary>
        /// Filter for whether an item has been played.
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? Played { get; set; }

        /// <summary>
        /// Filter for items that have been commented. 
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? Comment { get; set; }

        /// <summary>
        /// Filter for items marked for trade. 
        /// Set to false to exclude these items so marked. Set to true to include only these items so marked.
        /// </summary>
        public bool? Trade { get; set; }

        /// <summary>
        /// Filter for items wanted in trade. 
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? Want { get; set; }

        /// <summary>
        /// Filter for items on the wishlist.
        /// Set to false to exclude these items so marked. Set to true to include only these items so marked.
        /// </summary>
        public bool? WishList { get; set; }

        /// <summary>
        /// Filter for wishlist priority. Returns only items of the specified priority. Range 1..5
        /// </summary>
        public int? WishListPriority { get; set; }

        /// <summary>
        /// Filter for pre-ordered games Returns only items of the specified priority. 
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? PreOrdered { get; set; }

        /// <summary>
        /// Filter for items marked as wanting to play.
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? WantToPlay { get; set; }

        /// <summary>
        /// Filter for ownership flag. 
        /// Set to false to exclude these items so marked. Set to true to include only these items so marked.
        /// </summary>
        public bool? WantToBuy { get; set; }

        /// <summary>
        ///	Filter for games marked previously owned. 
        ///	Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? PrevOwned { get; set; }

        /// <summary>
        /// Filter on whether there is a comment in the Has Parts field of the item. 
        /// Set to False to exclude these items so marked. Set to True to include only these items so marked.
        /// </summary>
        public bool? HasParts { get; set; }

        /// <summary>
        /// Filter on whether there is a comment in the Wants Parts field of the item. 
        /// Set to false to exclude these items so marked. Set to true to include only these items so marked.
        /// </summary>
        public bool? WantParts { get; set; }

        /// <summary>
        /// Filter on maximum personal rating assigned for that item in the collection. Range 1..10
        /// </summary>
        public int? Rating { get; set; }

        /// <summary>
        /// Filter on minimum personal rating assigned for that item in the collection. Range 1..10
        /// </summary>
        public int? MinRating { get; set; }

        /// <summary>
        /// Filter on minimum BGG rating for that item in the collection. Range -1..10
        /// </summary>
        /// <remarks>Note: 0 is ignored... you can use -1 though, for example min -1 and max 1 to get items w/no bgg rating.</remarks>
        public int? MinBggRating { get; set; }

        /// <summary>
        /// Filter on maximum BGG rating for that item in the collection.Range -1..10
        /// </summary>
        /// <remarks>Note: 0 is ignored... you can use -1 though, for example min -1 and max 1 to get items w/no bgg rating.</remarks>
        public int? BggRating { get; set; }

        /// <summary>
        /// Filter by minimum number of recorded plays.
        /// </summary>
        public uint? MinPlays { get; set; }

        /// <summary>
        /// Filter by maximum number of recorded plays.
        /// </summary>
        public uint? MaxPlays { get; set; }

        /// <summary>
        /// Filter to show private collection info. Only works when viewing your own collection and you are logged in.
        /// </summary>
        public bool? ShowPrivate { get; set; }

        /// <summary>
        /// Restrict the collection results to the single specified collection id.
        /// Collid is returned in the results of normal queries as well.
        /// </summary>
        public uint? CollId { get; set; }

        /// <summary>
        /// Restricts the collection results to only those whose status (own, want, fortrade, etc.) 
        /// has changed or been added since the date specified (does not return results for deletions). 
        /// </summary>
        public DateTime? ModifiedSince { get; set; }
    }
}
