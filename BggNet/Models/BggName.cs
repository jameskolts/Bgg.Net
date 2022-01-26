namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents information about the Thing's name. 
    /// </summary>
    public class BggName
    {
        /// <summary>
        /// The string value of the name.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The type of the name.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The sort index of the name.
        /// </summary>
        public int? SortIndex { get; set; }
    }
}
