using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    [TestClass]
    public class ThingDeserializerTests
    {
        private readonly IThingDeserializer deserializer;

        public ThingDeserializerTests()
        {
            deserializer = new ThingDeserializer(Mock.Of<ILogger>());
        }
                       

        [TestMethod]
        public void DeserializeTest_Null()
        {
            //Act
            var result = deserializer.Deserialize(null);

            //Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public void DeserializeTest_Whitespace()
        {
            //Act
            var result = deserializer.Deserialize(" ");

            //Assert
            result.Should().BeNull();
        }
    }
}
