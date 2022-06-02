using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void Request_Valid()
        {
            //Arrange
            var request = new HotItemRequest(Types.HotItemType.Rpg);

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
