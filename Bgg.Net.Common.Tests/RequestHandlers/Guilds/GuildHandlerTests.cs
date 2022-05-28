﻿using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.Guilds;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.Guilds
{
    [TestClass]
    public class GuildHandlerTests : HandlerTestBase
    {
        private IGuildHandler? _handler;

        [TestMethod]
        public async Task GetGuild_Success()
        {
            //Arrange
            var request = new GuildRequest
            {
                Id = 2005,
                Members = true,
                Page = 2,
                Sort = SortType.UserName
            };

            MockValidatorFactory(new GuildRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockBggDeserializer(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetGuild(request);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("guild?id=2005&members=1&sort=username&page=2"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetGuildById()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockBggDeserializer(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetGuildById(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("guild?id=100"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetGuildByIdWithMembers()
        {
            //Arrange
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockBggDeserializer(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetGuildByIdWithMembers(100);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("guild?id=100&members=1&sort=username&page=1"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public async Task GetGuildExtensible_Success()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string> { "100" } },
                    {"members", new List<string> { "1" } },
                    {"page", new List<string> { "2" } },
                    {"sort", new List<string> { "username"} }
                }
            };

            MockValidatorFactory(new GuildRequestValidator());
            MockHttpClientGet(XmlGenerator.GenerateResourceXml(EmbeddedResource.GuildXml), HttpStatusCode.OK);
            MockBggDeserializer(new Guild { Id = 100 });

            _handler = new GuildHandler(_deserializerMock.Object, _loggerMock.Object, _httpClientMock.Object, _validatorFactory.Object);

            //Act
            var result = await _handler.GetGuildExtensible(extension);

            //Assert
            _httpClientMock.Verify(x => x.GetAsync("guild?id=100&members=1&page=2&sort=username"), Times.Once);
            result.Should().NotBeNull();
            result.Item.Id.Should().Be(100);
            result.HttpResponseCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
