using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class PlayRequestValidatorTests
    {
        private readonly PlayRequestValidator _validator;

        public PlayRequestValidatorTests()
        {
            _validator = new PlayRequestValidator();
        }

        [TestMethod]
        public void Request_MissingUserName_Missing_Id()
        {
            //Arrange
            var request = new PlaysRequest
            {
                MaxDate = new DateOnly(2020, 01, 01)
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element. Either username or id is required");
        }

        [TestMethod]
        public void Request_Both_UserName_Id()
        {
            //Arrange
            var request = new PlaysRequest
            {
                Id = 12345,
                UserName = "jonnhdm90"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Only one of 'username' or 'id' is allowed for PlaysRequest");
        }
    }
}
