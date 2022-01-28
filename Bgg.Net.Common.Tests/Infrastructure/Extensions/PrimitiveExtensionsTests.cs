using Bgg.Net.Common.Infrastructure.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bgg.Net.Common.Tests.Infrastructure.Extensions
{
    [TestClass]
    public class PrimitiveExtensionsTests
    {
        [TestMethod]
        public void ToNullableInt_Valid()
        {
            //Act
            var result = "24".ToNullableInt();

            //Assert
            result.Should().Be(24);
        }

        [TestMethod]
        public void ToNullableInt_InvalidDouble()
        {
            //Act
            var result = "24.343".ToNullableInt();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableInt_Whitespace()
        {
            //Act
            var result = " ".ToNullableInt();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableInt_Null()
        {
            //Arrange 
            string? s = null;

            //Act
            var result = s.ToNullableInt();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDouble_Valid()
        {
            //Act
            var result = "24.343".ToNullableDouble();

            //Assert
            result.Should().Be(24.343);
        }

        [TestMethod]
        public void ToNullableDouble_InvalidDouble()
        {
            //Act
            var result = "hello".ToNullableDouble();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDouble_Whitespace()
        {
            //Act
            var result = " ".ToNullableDouble();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDouble_Null()
        {
            //Arrange 
            string? s = null;

            //Act
            var result = s.ToNullableDouble();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableLong_Valid()
        {
            //Act
            var result = "2434354456".ToNullableLong();

            //Assert
            result.Should().Be(2434354456);
        }

        [TestMethod]
        public void ToNullableLong_InvalidLong()
        {
            //Act
            var result = "hello".ToNullableLong();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableLong_Whitespace()
        {
            //Act
            var result = " ".ToNullableLong();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableLong_Null()
        {
            //Arrange 
            string? s = null;

            //Act
            var result = s.ToNullableLong();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTime_Valid()
        {
            //Act
            var result = "12/24/1988".ToNullableDateTime();

            //Assert
            result.Should().Be(new DateTime(1988,12,24));
        }

        [TestMethod]
        public void ToNullableDateTime_InvalidDate()
        {
            //Act
            var result = "hello".ToNullableDateTime();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTime_Whitespace()
        {
            //Act
            var result = " ".ToNullableDateTime();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTime_Null()
        {
            //Arrange 
            string? s = null;

            //Act
            var result = s.ToNullableDateTime();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTimeOffset_Valid()
        {
            //Act
            var result = "12/24/1988".ToNullableDateTimeOffset();

            //Assert
            result.Should().Be(new DateTimeOffset(new DateTime(1988, 12, 24)));
        }

        [TestMethod]
        public void ToNullableDateTimeOffset_InvalidDate()
        {
            //Act
            var result = "hello".ToNullableDateTimeOffset();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTimeOffset_Whitespace()
        {
            //Act
            var result = " ".ToNullableDateTimeOffset();

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void ToNullableDateTimeOffset_Null()
        {
            //Arrange 
            string? s = null;

            //Act
            var result = s.ToNullableDateTimeOffset();

            //Assert
            result.Should().BeNull();
        }
    }
}
