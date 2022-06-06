using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class ForumRequestValidatorTests
    {
        private readonly ForumRequestValidator _validator;

        public ForumRequestValidatorTests()
        {
            _validator = new ForumRequestValidator();
        }

        [TestMethod]
        public void Request_IdDefault()
        {
            //Arrange
            var request = new ForumRequest();

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for ForumRequest: id");
        }
    }
}
