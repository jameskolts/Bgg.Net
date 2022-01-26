using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Versions
{
    public class Version
    {
        public VersionType? Type { get; set; }

        public long? Id { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }
    }
}
