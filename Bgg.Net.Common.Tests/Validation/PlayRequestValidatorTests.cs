using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;

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

        [TestMethod]
        public void Validate_LogPlayRequest_DefaultObjectId()
        {
            //Arrange
            var request = new LogPlayRequest
            {
                Ajax = 1,
                ObjectType = "thing",
                Action = "save"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("ObjectId was not set.");
        }

        [TestMethod]
        public void Validate_LogPlayRequest_DefaultAjaxId()
        {
            //Arrange
            var request = new LogPlayRequest
            {
                ObjectId = 500,
                ObjectType = "thing",
                Action = "save",
                Ajax = default
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Ajax was not set.");
        }

        [TestMethod]
        public void Validate_LogPlayRequest_InvalidType()
        {
            //Arrange
            var request = new LogPlayRequest
            {
                ObjectId = 500,
                Ajax = 1,
                ObjectType = "forum",
                Action = "save"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Invalid type: forum.");
        }

        [TestMethod]
        public void Validate_LogPlayRequest_InvalidAction()
        {
            //Arrange
            var request = new LogPlayRequest
            {
                ObjectId = 500,
                Ajax = 1,
                ObjectType = "thing",
                Action = "delete"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Invalid action: delete.");
        }
    }
}
