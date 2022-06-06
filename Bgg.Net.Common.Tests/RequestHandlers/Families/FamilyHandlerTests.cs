using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Families
{
    [TestClass]
    public class FamilyHandlerTests : HandlerTestBase
    {
        private IFamilyHandler? _handler;

        [TestMethod]
        public async Task GetFamily_Success()
        {
            //Arrange
            var request = new FamilyRequest
            {
                Id = new List<long> { 1 }
            };

            MockValidatorFactory(new FamilyRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.FamilyXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamily(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("family?id=1"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyById_Success()
        {
            //Arrange
            MockValidatorFactory(new FamilyRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.FamilyXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyById(1);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("family?id=1"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyByIds_Success()
        {
            //Arrange
            MockValidatorFactory(new FamilyRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.FamilyXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyByIds(new List<long> { 1, 2, 3 });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("family?id=1,2,3"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetFamilyByIdsAndType_Success()
        {
            //Arrange
            MockValidatorFactory(new FamilyRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.FamilyXml), HttpStatusCode.OK);
            MockBggDeserializer(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyByIdsAndType(new List<long> { 1, 2, 3 }, new List<FamilyType> { FamilyType.RpgPeriodical });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("family?id=1,2,3&type=rpgperiodical"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
