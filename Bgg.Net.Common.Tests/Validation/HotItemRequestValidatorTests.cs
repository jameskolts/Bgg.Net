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
    public class HotItemRequestValidatorTests
    {
        private readonly HotItemRequestValidator _validator;

        public HotItemRequestValidatorTests()
        {
            _validator = new HotItemRequestValidator();
        }

        [TestMethod]
        public void Extension_ValidType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
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
                    { "type", new List<string> { "orangeade" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'orangeade' was not valid for: type");
        }

        [TestMethod]
        public void Extension_MultipleType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "type", new List<string> { "boardgame", "rpg" } }
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
        public void Extension_EmptyType()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "type", new List<string>() }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for HotItemRequest: type");
        }

        [TestMethod]
        public void Request_ThrowsNotImplementedException()
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
