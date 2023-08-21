using Bgg.Net.Common.Infrastructure.Deserialization;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers;
using Bgg.Net.Common.RequestHandlers.Families;
using Bgg.Net.Common.Tests.Infrastructure.Deserialization;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using Bgg.Net.Common.Validation;
using Microsoft.Extensions.Logging;
using System.Net;

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
            MockDeserializerFactory(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });
            MockDeserializer(new FamilyList
            {
                Families = new List<Family> { new Family(), new Family() }
            });
            MockDeserializerFactory(new XmlDeserializer(Mock.Of<ILogger<XmlDeserializer>>()));

            _handler = new FamilyHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamily(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/family?id=1"), Times.Once);
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
            MockDeserializerFactory(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyById(1);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/family?id=1"), Times.Once);
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
            MockDeserializerFactory(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyByIds(new List<long> { 1, 2, 3 });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/family?id=1,2,3"), Times.Once);
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
            MockDeserializerFactory(
                new FamilyList
                {
                    Families = new List<Family> { new Family(), new Family() }
                });

            _handler = new FamilyHandler(_deserializerFactory.Object, Mock.Of<ILogger<RequestHandler>>(), _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetFamilyByIdsAndType(new List<long> { 1, 2, 3 }, new List<FamilyType> { FamilyType.RpgPeriodical });

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/family?id=1,2,3&type=rpgperiodical"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Should().NotBeNull();
            result.Item.Families.Count.Should().Be(2);
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
