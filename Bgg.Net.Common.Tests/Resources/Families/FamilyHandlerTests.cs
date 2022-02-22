using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.Resources.Families
{
    [TestClass]
    public class FamilyHandlerTests : HandlerTestBase
    {
        private IFamilyHandler? _handler;

        [TestMethod]
        public async Task GetFamilyById_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateFamilyXmlString(), HttpStatusCode.OK);

            _handler = new FamilyHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIFamilyDeserializer(XmlGenerator.GenerateFamilyXmlString()).Object);

            //Act
            var result = await _handler.GetFamilyById(1);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("family?id=1"), Times.Once);
            result.Should().NotBeNull();
            result.Items.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyByIds_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateFamilyXmlString(), HttpStatusCode.OK);

            _handler = new FamilyHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIFamilyDeserializer(XmlGenerator.GenerateFamilyXmlString()).Object);

            //Act
            var result = await _handler.GetFamilyByIds(new List<int> {1,2,3});

            //Assert
            httpClientMock.Verify(x => x.GetAsync("family?id=1,2,3"), Times.Once);
            result.Should().NotBeNull();
            result.Items.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyByIdsAndType_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateFamilyXmlString(), HttpStatusCode.OK);

            _handler = new FamilyHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIFamilyDeserializer(XmlGenerator.GenerateFamilyXmlString()).Object);

            //Act
            var result = await _handler.GetFamilyByIdsAndType(new List<int> { 1, 2, 3 }, new List<FamilyType> { FamilyType.RpgPeriodical });

            //Assert
            httpClientMock.Verify(x => x.GetAsync("family?id=1,2,3&type=rpgperiodical"), Times.Once);
            result.Should().NotBeNull();
            result.Items.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyExtensible_Success()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateFamilyXmlString(), HttpStatusCode.OK);

            _handler = new FamilyHandler(
                httpClientMock.Object,
                Mock.Of<ILogger>(),
                MockIFamilyDeserializer(XmlGenerator.GenerateFamilyXmlString()).Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1 } }
                }
            };

            //Act
            var result = await _handler.GetFamilyExtensible(extension);

            //Assert
            httpClientMock.Verify(x => x.GetAsync("family?id=1"), Times.Once);
            result.Should().NotBeNull();
            result.Items.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyExtensible_BadParameter()
        {
            //Arrange
            var httpClientMock = MockHttpClientGet(XmlGenerator.GenerateFamilyXmlString(), HttpStatusCode.OK);

            _handler = new FamilyHandler(
               httpClientMock.Object,
               Mock.Of<ILogger>(),
               MockIFamilyDeserializer(XmlGenerator.GenerateFamilyXmlString()).Object);

            var extension = new Extension
            {
                Value = new Dictionary<string, List<int>>
                {
                    { "id", new List<int> { 1 } },
                    { "badparameter", new List<int> { 1 } }
                }
            };

            //Act
            var result = await _handler.GetFamilyExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Should().Contain("'badparameter' parameter is not supported.");
            result.Items.Should().BeNullOrEmpty();
        }
    }
}
