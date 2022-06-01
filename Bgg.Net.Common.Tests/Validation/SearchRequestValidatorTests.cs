using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void Extension_MissingQuery()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "exact", new List<string> { "1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for SearchRequest: query");
        }

        [TestMethod]
        public void Extension_EmptyQuery()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string>() }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element: query");
        }

        [TestMethod]
        public void Extension_ValidQuery()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MultipleQuery()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova", "carthage"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: query");
        }

        [TestMethod]
        public void Extension_ValidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "type", new List<string> { "rpgitem"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MultipleType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "type", new List<string> { "rpgitem", "boardgameaccessory"} }
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
                    { "query", new List<string> { "ark nova"} },
                    { "type", new List<string> { "badThing"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'badThing' was not valid for: type");
        }

        [TestMethod]
        public void Extension_ValidExact()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "exact", new List<string> { "1"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MultipleExact()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "exact", new List<string> { "0", "1"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: exact");
        }

        [TestMethod]
        public void Extension_InValidExact()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "exact", new List<string> { "none"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'none' was not valid for: exact");
        }

        [TestMethod]
        public void Extension_BadParam()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "query", new List<string> { "ark nova"} },
                    { "badParam", new List<string> { "none"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("'badParam' parameter is not supported for SearchExtensible");
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
