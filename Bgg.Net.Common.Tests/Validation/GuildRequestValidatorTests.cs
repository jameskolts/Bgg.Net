using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class GuildRequestValidatorTests
    {
        private readonly GuildRequestValidator _validator;

        public GuildRequestValidatorTests()
        {
            _validator = new GuildRequestValidator();
        }

        [TestMethod]
        public void Request_MissingId()
        {
            //Arrange
            var request = new GuildRequest();

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for GuildRequest: id");
        }

        [TestMethod]
        public void Request_Valid()
        {
            //Arrange
            var request = new GuildRequest
            {
                Id = 12345,
                Members = true
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}
