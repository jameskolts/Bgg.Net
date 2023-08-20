using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class ThingRequestValidatorTests
    {
        private readonly ThingRequestValidator _validator;

        public ThingRequestValidatorTests()
        {
            _validator = new ThingRequestValidator();
        }

        [TestMethod]
        public void Request_MissingId()
        {
            //Arrange
            var request = new ThingRequest
            {
                Page = 1
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for ThingRequest: id");
        }
    }
}
