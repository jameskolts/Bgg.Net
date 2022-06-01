using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        public void Extension_MissingUserName_MissingId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"type", new List<string>{ "thing"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for PlaysRequest. Either username or id is required");
        }

        [TestMethod]
        public void Extension_UserName_MissingId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"username", new List<string>{ "mickey"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_MissingUserName_Id()
        {
            //Arrange
            var extension = new Extension();
            extension.AddValue("Id", new List<string> { "1235" });

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_Both_UserName_Id()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"username", new List<string>{"johnny" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one of 'username' or 'id' is allowed for PlaysRequest");
        }

        [TestMethod]
        public void Extension_Dates()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"mindate", new List<string>{"2020-01-01" } },
                    {"maxdate", new List<string>{"2021-01-01"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_DatesInvalid()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"mindate", new List<string>{"january 1st 2020" } },
                    {"maxdate", new List<string>{"2020 march 1", "2020-02-02"} }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
            result.Errors.Should().Contain("The value 'january 1st 2020' was not valid for: mindate");
            result.Errors.Should().Contain("Only one value is allowed for: maxdate");
        }

        [TestMethod]
        public void Extension_ValidSubType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"subtype", new List<string>{"rpgitem" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InvalidSubtype()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"subtype", new List<string>{"blarg" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'blarg' was not valid for: subtype");
        }

        [TestMethod]
        public void Extension_MultipleSubtype()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"subtype", new List<string>{"rpgitem", "videogame" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: subtype");
        }

        [TestMethod]
        public void Extension_ValidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"type", new List<string>{"family" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_Invalidtype()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"type", new List<string>{"blarg" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'blarg' was not valid for: type");
        }

        [TestMethod]
        public void Extension_MultipleType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"type", new List<string>{"family", "thing" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Only one value is allowed for: type");
        }

        [TestMethod]
        public void Extension_ValidPage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"page", new List<string>{"12" } }
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
                    {"id", new List<string>{ "12345"} },
                    {"page", new List<string>{"axed" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'axed' was not valid for: page");
        }

        [TestMethod]
        public void Extension_NegativePage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"page", new List<string> { "-1" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value '-1' was not valid for: page");
        }

        [TestMethod]
        public void Extension_MultiplePage()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    {"id", new List<string>{ "12345"} },
                    {"page", new List<string> { "1", "3" } }
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
