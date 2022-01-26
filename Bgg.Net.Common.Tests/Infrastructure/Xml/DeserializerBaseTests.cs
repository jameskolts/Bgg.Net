using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Tests.TestWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FluentAssertions;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{   

    [TestClass]
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    public class DeserializerBaseTests
    {
        private readonly DeserializerBaseTestWrapper deserializer;
        private readonly XmlElement root;
        private const string _rootXpath = "//items/item";

        public DeserializerBaseTests()
        {
            deserializer = new DeserializerBaseTestWrapper("//items/item");
            root = XmlGenerator.GenerateThingXmlElement();
        }

        [TestMethod]
        public void DeserializeLink_Success()
        {
            //Arrange
            var nodeList = root.SelectNodes($"{_rootXpath}/link");

            //Act
            var result = deserializer.DeseralizeLink(nodeList);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(23);
            result[0].Type.Should().Be("boardgamecategory");
            result[0].Id.Should().Be(1021);
            result[0].Value.Should().Be("Economic");
            result[1].Type.Should().Be("boardgamecategory");
            result[1].Id.Should().Be(1026);
            result[1].Value.Should().Be("Negotiation");
            result[2].Type.Should().Be("boardgamecategory");
            result[2].Id.Should().Be(1001);
            result[2].Value.Should().Be("Political");
        }

        [TestMethod]
        public void DeserializeLink_Null()
        {
            //Act
            var result = deserializer.DeseralizeLink(null);

            //Assert
            result.Should().BeNull();
        }
    }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
