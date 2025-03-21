﻿using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;

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
            var request = new HotItemRequest("rpg");

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
