using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class ForumListRequestValidatorTests
    {
        private readonly ForumListRequestValidator _validator;

        public ForumListRequestValidatorTests()
        {
            _validator = new ForumListRequestValidator();
        }

        [TestMethod]
        public void Request_IdDefault()
        {
            //Arrange
            var request = new ForumListRequest();

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for ForumListRequest: id");
        }
    }
}
