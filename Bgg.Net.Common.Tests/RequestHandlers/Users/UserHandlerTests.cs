using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models.Bgg;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Users;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Users
{
    [TestClass]
    public class UserHandlerTests : HandlerTestBase
    {
        private IUserHandler? _handler;

        [TestMethod]
        public async Task GetUserByName_Success()
        {
            //Arrange
            MockValidatorFactory(new UserRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act 
            var result = await _handler.GetUserByName("inigoMontoya");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/user?name=inigomontoya"), Times.Once);
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Item.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.Errors.Should().BeNullOrEmpty();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetUserByName_Failure()
        {
            //Arrange
            MockValidatorFactory(new UserRequestValidator());
            MockHttpClientGet(string.Empty, HttpStatusCode.NotFound);
            _deserializerMock = new Mock<IBggDeserializer>();

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act 
            var result = await _handler.GetUserByName("inigoMontoya");

            //Assert
            result.Should().NotBeNull();
            result.Item.Should().BeNull();
            result.IsSuccessful.Should().BeFalse();
            result.HttpResponseCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetUser_Success()
        {
            //Arrange
            var request = new UserRequest("userName")
            {
                Domain = "boardgame",
                Buddies = true,
                Guilds = true,
                Hot = false,
                Page = 2,
                Top = true,

            };

            MockValidatorFactory(new UserRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object, _queryBuilder.Object);

            //Act
            var result = await _handler.GetUser(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync($"{Constants.XmlApi2Route}/user?name=username&buddies=1&guilds=1&hot=0&top=1&domain=boardgame&page=2"));
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
