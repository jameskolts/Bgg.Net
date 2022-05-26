using Bgg.Net.Common.Models;

namespace Bgg.Net.Common.Types
{
    /// <summary>
    /// The subtype of an item.
    /// </summary>
    /// <remarks>
    /// Used in <seealso cref="PlayList"/>.
    /// </remarks>
    public enum ItemSubType
    {
        BoardGame,
        BoardGameExpansion,
        BoardGameAccessory,
        BoardGameIntegration,
        BoardGameCompilation,
        BoardGameImplementation,
        Rpg,
        RpgItem,
        VideoGame
    }
}
