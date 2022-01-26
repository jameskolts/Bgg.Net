using Bgg.Net.Common.Types;

namespace Bgg.Net.Common.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static VersionType? ToVersionType(this string value)
        {
            switch (value.ToLower())
            {
                case "boardgameversion":
                    return VersionType.BoardGame;
                case "videogame":
                    return VersionType.VideoGame;
                case "videogamecharacter":
                    return VersionType.VideoGameCharacter;
                default:
                    return null;
            }
        }
    }
}
