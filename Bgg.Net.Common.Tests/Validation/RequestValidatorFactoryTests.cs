using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bgg.Net.Common.Validation
{
    [TestClass]
    public class RequestValidatorFactoryTests
    {
        private readonly RequestValidatorFactory _validatorFactory;

        public RequestValidatorFactoryTests()
        {
            _validatorFactory = new RequestValidatorFactory();
        }

        [TestMethod]
        public void ThingValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("thing");

            //Assert
            result.Should().BeAssignableTo<ThingRequestValidator>();
            result.GetType().Name.Should().Be("ThingRequestValidator");
        }

        [TestMethod]
        public void FamilyValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("family");

            //Assert
            result.Should().BeAssignableTo<FamilyRequestValidator>();
            result.GetType().Name.Should().Be("FamilyRequestValidator");
        }

        [TestMethod]
        public void CollectionValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("collection");

            //Assert
            result.Should().BeAssignableTo<CollectionRequestValidator>();
            result.GetType().Name.Should().Be("CollectionRequestValidator");
        }

        [TestMethod]
        public void GuildValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("guild");

            //Assert
            result.Should().BeAssignableTo<GuildRequestValidator>();
            result.GetType().Name.Should().Be("GuildRequestValidator");
        }

        [TestMethod]
        public void HotValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("hot");

            //Assert
            result.Should().BeAssignableTo<HotItemRequestValidator>();
            result.GetType().Name.Should().Be("HotItemRequestValidator");
        }

        [TestMethod]
        public void PlaysValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("plays");

            //Assert
            result.Should().BeAssignableTo<PlayRequestValidator>();
            result.GetType().Name.Should().Be("PlayRequestValidator");
        }

        [TestMethod]
        public void SearchValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("search");

            //Assert
            result.Should().BeAssignableTo<SearchRequestValidator>();
            result.GetType().Name.Should().Be("SearchRequestValidator");
        }

        [TestMethod]
        public void ThreadValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("thread");

            //Assert
            result.Should().BeAssignableTo<ThreadRequestValidator>();
            result.GetType().Name.Should().Be("ThreadRequestValidator");
        }

        [TestMethod]
        public void UserValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("user");

            //Assert
            result.Should().BeAssignableTo<UserRequestValidator>();
            result.GetType().Name.Should().Be("UserRequestValidator");
        }

        [TestMethod]
        public void ForumValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("forum");

            //Assert
            result.Should().BeAssignableTo<ForumRequestValidator>();
            result.GetType().Name.Should().Be("ForumRequestValidator");
        }

        [TestMethod]
        public void ForumListValidator()
        {
            //Act
            var result = _validatorFactory.CreateRequestValidator("forumlist");

            //Assert
            result.Should().BeAssignableTo<ForumListRequestValidator>();
            result.GetType().Name.Should().Be("ForumListRequestValidator");
        }

        [TestMethod]
        public void NotSupported()
        {
            //Act
            Action act = () => _validatorFactory.CreateRequestValidator("badType");

            //Assert
            act.Should().Throw<NotImplementedException>();
        }

        [TestMethod]
        public void NullType()
        {
            //Act
            Action act = () => _validatorFactory.CreateRequestValidator(null);

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhiteSpace()
        {
            //Act
            Action act = () => _validatorFactory.CreateRequestValidator(" ");

            //Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
