namespace Bgg.Net.Common.Models
{
    public class Listing
    {
        public DateTime? ListDate { get; set; }

        public Price Price { get; set; }

        public string Condition { get; set; }

        public string Notes { get; set; }

        public ListingLink Link { get; set; }
    }
}
