using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Infrastructure.Xml.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    [TestClass]
    public class FamilyDeserializerTests
    {
        private readonly IFamilyDeserializer deserializer;

        public FamilyDeserializerTests()
        {
            deserializer = new FamilyDeserializer(Mock.Of<ILogger>());
        }

        [TestMethod]
        public void DeserializeFamilies_Success()
        {
            //Act
            var result = deserializer.Deserialize(XmlGenerator.GenerateFamilyXmlString());

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Count.Should().Be(2);

            var family = result[0];

            family.Type.Should().Be("boardgamefamily");
            family.Id.Should().Be(4);
            family.Thumbnail.Should().Be("https://cf.geekdo-images.com/TeW2-Qo-yWwe19v-RaUnLQ__thumb/img/jTctkjj7ajx3Jhd0OBe4nPz5K9Q=/fit-in/200x150/filters:strip_icc()/pic680679.jpg");
            family.Name.Count.Should().Be(4);
            family.Name[0].Type.Should().Be("primary");
            family.Name[0].SortIndex.Should().Be(1);
            family.Name[0].Value.Should().Be("Series: The Chicken Family of Zoch");
            family.Name[1].Value.Should().Be("Series: Chicken World");
            family.Image.Should().Be("https://cf.geekdo-images.com/TeW2-Qo-yWwe19v-RaUnLQ__original/img/4U5hid4FIsZUoRZlIJCYQRLvY-I=/0x0/filters:format(jpeg)/pic680679.jpg");
            family.Description.Should().StartWith("The Chicken Family of Zoch (");
            family.Link.Count.Should().Be(18);
            family.Link[0].Type.Should().Be("boardgamefamily");
            family.Link[0].Id.Should().Be(3507);
            family.Link[0].Value.Should().Be("By Golly!");
            family.Link[0].Inbound.Should().Be(true);

            family = result[1];
            family.Name.Count.Should().Be(1);
            family.Name[0].Value.Should().Be("Game: Bohnanza");
        }
    }
}
