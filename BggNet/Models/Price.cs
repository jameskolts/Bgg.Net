namespace Bgg.Net.Common.Models
{
    /// <summary>
    /// Represents the price of an item on BGG.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// The currency denomination used.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Price value of the item.
        /// </summary>
        public double? Value;
    }
}
