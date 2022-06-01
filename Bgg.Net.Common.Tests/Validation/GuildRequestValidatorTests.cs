using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void Extension_MissingId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "members", new List<string> { "1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for GuildRequest: id");
        }

        [TestMethod]
        public void Extension_MultipleId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "1", "2", "3" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: id");
        }

        [TestMethod]
        public void Extension_InvalidId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "kerfluffle" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'kerfluffle' was not valid for: id");
        }

        [TestMethod]
        public void Extension_EmptyId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string>() }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element: id");
        }

        [TestMethod]
        public void Extension_ValidMembers()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "members",  new List<string> { "1" }}
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MultipleMembers()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "members",  new List<string> { "1", "2" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: members");
        }

        [TestMethod]
        public void Extension_InvalidMembers()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "members",  new List<string> { "true" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'true' was not valid for: members");
        }

        [TestMethod]
        public void Extension_ValidSort()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "sort",  new List<string> { "username" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MultipleSort()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "sort",  new List<string> { "username", "date" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: sort");
        }

        [TestMethod]
        public void Extension_InvalidSort()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "sort",  new List<string> { "boardgame" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'boardgame' was not valid for: sort");
        }

        [TestMethod]
        public void Extension_InvalidPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "page",  new List<string> { "boardgame" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'boardgame' was not valid for: page");
        }

        [TestMethod]
        public void Extension_MultiplePage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "page",  new List<string> { "1", "2" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: page");
        }

        [TestMethod]
        public void Extension_ValidPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "page",  new List<string> { "1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_BadParam()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345" } },
                    { "BadParam",  new List<string> { "1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("'BadParam' parameter is not supported for: GetGuildExtensible");
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
