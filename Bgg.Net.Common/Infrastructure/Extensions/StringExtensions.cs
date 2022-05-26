using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalizes the first char of a string.
        /// </summary>
        /// <param name="str">The string to capitalize.</param>
        /// <returns>The string with the first char capitalized.</returns>
        public static string UpperFirstChar(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            return char.ToUpper(str[0]) + str[1..];
        }

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
