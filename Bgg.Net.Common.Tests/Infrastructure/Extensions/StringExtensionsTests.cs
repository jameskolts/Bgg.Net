using Bgg.Net.Common.Infrastructure.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Infrastructure.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
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
            string? value = null;
            value.UpperFirstChar().Should().BeNull();
        }

        [TestMethod]
        public void UpperFirstChar_Valid()
        {
            "hello".UpperFirstChar().Should().Be("Hello");
        }
    }
}
