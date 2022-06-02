using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class UserRequestValidationTests
    {
        private readonly UserRequestValidator _validator;

        public UserRequestValidationTests()
        {
            _validator = new UserRequestValidator();
        }

        [TestMethod]
        public void Request_NameNull()
        {
            //Arrange
            var request = new UserRequest(null);

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for UserRequest: name");
        }

        [TestMethod]
        public void Request_NameWhitespace()
        {
            //Arrange
            var request = new UserRequest(" ");

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for UserRequest: name");
        }

        [TestMethod]
        public void Request_ValidNamee()
        {
            //Arrange
            var request = new UserRequest("name");

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
