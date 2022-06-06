using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class CollectionRequestValidatorTests
    {
        private readonly IRequestValidator _validator;

        public CollectionRequestValidatorTests()
        {
            _validator = new CollectionRequestValidator();
        }

        [TestMethod]
        public void Request_MissingUserName()
        {
            //Arrange
            var request = new CollectionRequest
            {
                UserName = null,
                BggRating = 5
            };

            //Act
            var result = _validator.Validate(request);

            //assert    
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for CollectionRequest: userName");
        }
    }
}
