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
    public class FamilyRequestValidatorTests
    {
        private readonly FamilyRequestValidator _validator;

        public FamilyRequestValidatorTests()
        {
            _validator = new FamilyRequestValidator();
        }

        [TestMethod]
        public void Extension_MissingId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "type", new List<string> { "rpg" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for FamilyRequest: id");
        }

        [TestMethod]
        public void Extension_MultipleId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123", "35", "2432"} },
                    { "type", new List<string> { "rpg" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InvalidId()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123", "35", "argonaut"} },
                    { "type", new List<string> { "rpg" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'argonaut' was not valid for: id");
        }

        [TestMethod]
        public void Extension_MultipleType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123", "35"} },
                    { "type", new List<string> { "rpg", "boardgamefamily" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InvalidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "id", new List<string> { "123", "35"} },
                    { "type", new List<string> { "rpg", "kerfluffle" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'kerfluffle' was not valid for: type");
        }

        [TestMethod]
        public void Request_ThrowsNotImplemented()
        {
            //Arrange
            var request = new CollectionRequest();

            //Act
            Action act = () => _validator.Validate(request);

            //Assert
            act.Should().Throw<NotImplementedException>();
        }
    }
}
