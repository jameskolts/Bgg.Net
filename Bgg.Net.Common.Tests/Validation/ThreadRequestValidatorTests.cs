using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class ThreadRequestValidatorTests
    {
        private readonly ThreadRequestValidator _validator;

        public ThreadRequestValidatorTests()
        {
            _validator = new ThreadRequestValidator();
        }

        [TestMethod]
        public void Request_DefaultId()
        {
            //Arrange
            var request = new ThreadRequest(default)
            {
                Count = 1
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for ThreadRequest: id");
        }
    }
}
