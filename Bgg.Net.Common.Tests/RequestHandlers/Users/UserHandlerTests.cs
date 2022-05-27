﻿using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Xml;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Users;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
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
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act 
            var result = await _handler.GetUserByName("inigoMontoya");

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("user?name=inigoMontoya"), Times.Once);
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
            MockHttpClientGet(string.Empty, HttpStatusCode.NotFound);
            _deserializerMock = new Mock<IBggDeserializer>();

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

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
                Domain = DomainType.BoardGame,
                Buddies = true,
                Guilds = true,
                Hot = false,
                Page = 2,
                Top = true,

            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetUser(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("user?name=username&buddies=1&guilds=1&hot=0&top=1&domain=boardgame&page=2"));
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetUserExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"name", new List<string> { "sam" } }
                }
            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetUserExtensible(extension);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("user?name=sam"), Times.Once);
            result.Should().NotBeNull();
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
            result.Item.Id.Should().Be(100);
        }

        [TestMethod]
        public async Task GetUserExtensible_BadParameter()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"badparam", new List<string> { "sam" } }
                }
            };

            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.UserXml), HttpStatusCode.OK);
            MockBggDeserializer(new User { Id = 100 });

            _handler = new UserHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object);

            //Act
            var result = await _handler.GetUserExtensible(extension);

            //Assert
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Errors.Should().Contain("'badparam' parameter is not supported for GetUserExtensible.");
            result.Item.Should().BeNull();
        }
    }
}
