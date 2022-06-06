using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class SearchRequestValidatorTests
    {
        private readonly SearchRequestValidator _validator;

        public SearchRequestValidatorTests()
        {
            _validator = new SearchRequestValidator();
        }

        [TestMethod]
        public void Request_MissingQuery()
        {
            //Arrange
            var request = new SearchRequest("")
            {
                Exact = true
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for SearchRequest: query");
        }
    }
}
