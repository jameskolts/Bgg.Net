using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for Enumerated Types.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Parses a string to a version type.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>A version type, or null.</returns>
        public static VersionType? ToVersionType(this string value)
        {
            return value.ToLower() switch
            {
                "boardgameversion" => VersionType.BoardGame,
                "videogame" => VersionType.VideoGame,
                "videogamecharacter" => VersionType.VideoGameCharacter,
                _ => null,
            };
        }
    }
}
