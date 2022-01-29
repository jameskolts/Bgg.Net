using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Infrastructure.Extensions
{
    [TestClass]
    public class TypeExtensionsTests
    {
        [TestMethod]
        public void ToVersionType_Boardgame()
        {
            // Act/Assert
            "boardgameversion".ToVersionType().Should().Be(VersionType.BoardGame);
        }

        [TestMethod]
        public void ToVersionType_VideoGame()
        {
            // Act/Assert
            "videogame".ToVersionType().Should().Be(VersionType.VideoGame);
        }

        [TestMethod]
        public void ToVersionType_VideoGameCharacter()
        {
            // Act/Assert
            "videogamecharacter".ToVersionType().Should().Be(VersionType.VideoGameCharacter);
        }

        [TestMethod]
        public void ToVersionType_Invalid()
        {
            // Act/Assert
            "anything else".ToVersionType().Should().BeNull();
        }
    }
}
