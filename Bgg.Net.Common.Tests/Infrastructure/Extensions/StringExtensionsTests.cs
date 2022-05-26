using Bgg.Net.Common.Infrastructure.Extensions;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Infrastructure.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ToVersionType_Boardgame()
        {
            "boardgameversion".ToVersionType().Should().Be(VersionType.BoardGame);
        }

        [TestMethod]
        public void ToVersionType_VideoGame()
        {
            "videogame".ToVersionType().Should().Be(VersionType.VideoGame);
        }

        [TestMethod]
        public void ToVersionType_VideoGameCharacter()
        {
            "videogamecharacter".ToVersionType().Should().Be(VersionType.VideoGameCharacter);
        }

        [TestMethod]
        public void ToVersionType_Invalid()
        {
            "anything else".ToVersionType().Should().BeNull();
        }

        [TestMethod]
        public void UpperFirstChar_Empty()
        {
            string.Empty.UpperFirstChar().Should().BeNull();
        }

        [TestMethod]
        public void UpperFirstChar_WhiteSpace()
        {
            " ".UpperFirstChar().Should().BeNull();
        }

        [TestMethod]
        public void UpperFirstChar_Null()
        {
            string value = null;
            value.UpperFirstChar().Should().BeNull();
        }

        [TestMethod]
        public void UpperFirstChar_Valid()
        {
            "hello".UpperFirstChar().Should().Be("Hello");
        }
    }
}
