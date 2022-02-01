using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Models.Versions
{
    /// <summary>
    /// The base class for versions represents in BGG.
    /// </summary>
    public class Version
    {
        public VersionType? Type { get; set; }

        public long? Id { get; set; }

        public string Thumbnail { get; set; }

        public string Image { get; set; }
    }
}
