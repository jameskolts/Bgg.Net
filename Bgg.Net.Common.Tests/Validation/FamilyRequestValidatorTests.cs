using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class FamilyRequestValidatorTests
    {
        private readonly FamilyRequestValidator _validator;

        public FamilyRequestValidatorTests()
        {
            _validator = new FamilyRequestValidator();
        }

        [TestMethod]
        public void Request_EmptyId()
        {
            //Arrange
            var request = new FamilyRequest();

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for FamilyRequest: id");
        }
    }
}
