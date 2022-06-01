using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void Extension_ValidId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123453" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InValidId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "string" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'string' was not valid for: id");
        }

        [TestMethod]
        public void Extension_MultipleId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345", "183783" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_EmptyId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string>() },
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
        public void Extension_MissingId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "type", new List<string>() },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("Missing required element for ThingRequest: id");
        }

        [TestMethod]
        public void Extension_ValidBools()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123453" } },
                    { "versions", new List<string> { "1" } },
                    { "videos", new List<string> { "1" } },
                    { "stats", new List<string> { "1" } },
                    { "marketplace", new List<string> { "1" } },
                    { "comments", new List<string> { "1" } },
                    { "ratingcomments", new List<string> { "1" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InValidBools()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123456" } },
                    { "versions", new List<string> { "true" } },
                    { "videos", new List<string> { "true" } },
                    { "stats", new List<string> { "true" } },
                    { "marketplace", new List<string> { "true" } },
                    { "comments", new List<string> { "true" } },
                    { "ratingcomments", new List<string> { "true" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(6);
            result.Errors.Should().Contain("The value 'true' was not valid for: versions");
            result.Errors.Should().Contain("The value 'true' was not valid for: videos");
            result.Errors.Should().Contain("The value 'true' was not valid for: stats");
            result.Errors.Should().Contain("The value 'true' was not valid for: marketplace");
            result.Errors.Should().Contain("The value 'true' was not valid for: comments");
            result.Errors.Should().Contain("The value 'true' was not valid for: ratingcomments");
        }

        [TestMethod]
        public void Extension_MultipleBools()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345", "183783" } },
                    { "versions", new List<string> { "0", "1" } },
                    { "videos", new List<string> { "0", "1" } },
                    { "stats", new List<string> { "0", "1" } },
                    { "marketplace", new List<string> { "0", "1" } },
                    { "comments", new List<string> { "0", "1" } },
                    { "ratingcomments", new List<string> { "0", "1" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(6);
            result.Errors.Should().Contain("Only one value is allowed for: versions");
            result.Errors.Should().Contain("Only one value is allowed for: videos");
            result.Errors.Should().Contain("Only one value is allowed for: stats");
            result.Errors.Should().Contain("Only one value is allowed for: marketplace");
            result.Errors.Should().Contain("Only one value is allowed for: comments");
            result.Errors.Should().Contain("Only one value is allowed for: ratingcomments");
        }

        [TestMethod]
        public void Extension_EmptyBools()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "1234" } },
                    { "versions", new List<string>() },
                    { "videos", new List<string>() },
                    { "stats", new List<string>()},
                    { "marketplace", new List<string>()},
                    { "comments", new List<string> () },
                    { "ratingcomments", new List<string>()},
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(6);
            result.Errors.Should().Contain("The value '' was not valid for: versions");
            result.Errors.Should().Contain("The value '' was not valid for: videos");
            result.Errors.Should().Contain("The value '' was not valid for: stats");
            result.Errors.Should().Contain("The value '' was not valid for: marketplace");
            result.Errors.Should().Contain("The value '' was not valid for: comments");
            result.Errors.Should().Contain("The value '' was not valid for: ratingcomments");
        }

        [TestMethod]
        public void Extension_ValidPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123453" } },
                    { "page", new List<string> { "1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InValidPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "string" } },
                    { "page", new List<string> { "xd" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("The value 'xd' was not valid for: page");
        }

        [TestMethod]
        public void Extension_MultiplePage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345", "183783" } },
                    { "page", new List<string> { "1", "2" } }
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
        public void Extension_EmptyPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> {"12345" } },
                    { "page", new List<string>() }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("The value '' was not valid for: page");
        }

        [TestMethod]
        public void Extension_ValidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123453" } },
                    { "type", new List<string> { "boardgame" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InValidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "string" } },
                    { "type", new List<string> { "xd" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain("The value 'xd' was not valid for: type");
        }

        [TestMethod]
        public void Extension_MultipleType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12345", "183783" } },
                    { "type", new List<string> { "boardgame", "boardgameexpansion" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_EmptyType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "12355" } },
                    { "type", new List<string>() }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
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
