using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Infrastructure.Validation;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Bgg.Net.Common.Tests.Validation
{
    [TestClass]
    public class CollectionRequestValidatorTests
    {
        private IRequestValidator _validator;

        public CollectionRequestValidatorTests()
        {
            _validator = new CollectionRequestValidator();
        }

        [TestMethod]
        public void Extension_MissingUsername()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "version", new List<string> {"1" } },
                    { "subtype", new List<string> { "boardgame" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors[0].Should().Be($"Missing required element for CollectionRequest: userName");
        }

        [TestMethod]
        public void Extension_ValidBools()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "version", new List<string> {"1" } },
                    { "brief", new List<string> {"1" } },
                    { "stats", new List<string> {"0" } },
                    { "own", new List<string> {"0" } },
                    { "rated", new List<string> {"1" } },
                    { "played", new List<string> {"1" } },
                    { "comment", new List<string> {"1" } },
                    { "trade", new List<string> {"1" } },
                    { "want", new List<string> {"1" } },
                    { "wishlist", new List<string> {"1" } },
                    { "preordered", new List<string> {"1" } },
                    { "wanttoplay", new List<string> {"1" } },
                    { "wanttobuy", new List<string> {"1" } },
                    { "prevowned", new List<string> {"1" } },
                    { "hasparts", new List<string> {"1" } },
                    { "wantparts", new List<string> {"1" } },
                    { "showprivate", new List<string> {"1" } },
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
                    { "username", new List<string> {"aUserName" } },
                    { "version", new List<string> {"true" } },
                    { "brief", new List<string> {"false" } },
                    { "stats", new List<string> {"string" } },
                    { "own", new List<string> { "string" } },
                    { "rated", new List<string> { "string" } },
                    { "played", new List<string> { "string" } },
                    { "comment", new List<string> { "string" } },
                    { "trade", new List<string> { "string" } },
                    { "want", new List<string> { "string" } },
                    { "wishlist", new List<string> { "string" } },
                    { "preordered", new List<string> {"string" } },
                    { "wanttoplay", new List<string> { "string" } },
                    { "wanttobuy", new List<string> { "string" } },
                    { "prevowned", new List<string> { "string" } },
                    { "hasparts", new List<string> { "string" } },
                    { "wantparts", new List<string> { "string" } },
                    { "showprivate", new List<string> { "string" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(17);
            result.Errors.Should().Contain("The value 'true' was not valid for: version");
            result.Errors.Should().Contain("The value 'false' was not valid for: brief");
            result.Errors.Should().Contain("The value 'string' was not valid for: stats");
            result.Errors.Should().Contain("The value 'string' was not valid for: own");
            result.Errors.Should().Contain("The value 'string' was not valid for: rated");
            result.Errors.Should().Contain("The value 'string' was not valid for: played");
            result.Errors.Should().Contain("The value 'string' was not valid for: comment");
            result.Errors.Should().Contain("The value 'string' was not valid for: trade");
            result.Errors.Should().Contain("The value 'string' was not valid for: want");
            result.Errors.Should().Contain("The value 'string' was not valid for: wishlist");
            result.Errors.Should().Contain("The value 'string' was not valid for: preordered");
            result.Errors.Should().Contain("The value 'string' was not valid for: wanttoplay");
            result.Errors.Should().Contain("The value 'string' was not valid for: wanttobuy");
            result.Errors.Should().Contain("The value 'string' was not valid for: prevowned");
            result.Errors.Should().Contain("The value 'string' was not valid for: hasparts");
            result.Errors.Should().Contain("The value 'string' was not valid for: wantparts");
            result.Errors.Should().Contain("The value 'string' was not valid for: showprivate");
        }

        [TestMethod]
        public void Extension_ValidNumbers()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "id", new List<string> { "12345" } },
                    { "wishlistpriority", new List<string> { "3" } },
                    { "minrating", new List<string> { "5" } },
                    { "rating", new List<string> { "5" } },
                    { "minbggrating", new List<string> { "5" } },
                    { "bggrating", new List<string> { "5" } },
                    { "minplays", new List<string> { "120" } },
                    { "maxplays", new List<string> { "120" } },
                    { "collid", new List<string> { "120" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void Extension_InValidNumbers()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "id", new List<string> { "happy" } },
                    { "wishlistpriority", new List<string> { "25" } },
                    { "minrating", new List<string> { "-5" } },
                    { "rating", new List<string> { ".34" } },
                    { "minbggrating", new List<string> { "a" } },
                    { "bggrating", new List<string> { " " } },
                    { "minplays", new List<string> { "-52" } },
                    { "maxplays", new List<string> { "false" } },
                    { "collid", new List<string> { "-1" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(9);
            result.Errors.Should().Contain("The value 'happy' was not valid for: id");
            result.Errors.Should().Contain("The value '25' was not valid for: wishlistpriority");
            result.Errors.Should().Contain("The value '-5' was not valid for: minrating");
            result.Errors.Should().Contain("The value '.34' was not valid for: rating");
            result.Errors.Should().Contain("The value 'a' was not valid for: minbggrating");
            result.Errors.Should().Contain("The value ' ' was not valid for: bggrating");
            result.Errors.Should().Contain("The value '-52' was not valid for: minplays");
            result.Errors.Should().Contain("The value 'false' was not valid for: maxplays");
            result.Errors.Should().Contain("The value '-1' was not valid for: collid");
        }

        [TestMethod]
        public void Extension_InValidEnums()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "subtype", new List<string> { "astring" } },
                    { "excludesubtype", new List<string> { "astring2" } },
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
            result.Errors.Should().Contain("The value 'astring' was not valid for: subtype");
            result.Errors.Should().Contain("The value 'astring2' was not valid for: excludesubtype");
        }

        [TestMethod]
        public void Extension_TooManyEnums()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "subtype", new List<string> { "boardgame", "boardgameaccessory" } },
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
        public void Extension_ValidDateTime()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "modifiedSince", new List<string> { "2020-01-01" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();           
        }

        [TestMethod]
        public void Extension_InValidDateTime()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "modifiedSince", new List<string> { "year of our lord 1822" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("The value 'year of our lord 1822' was not valid for: modifiedSince");
        }

        [TestMethod]
        public void Extension_BadParam()
        {
            //Arrange
            var extension = new Extension
            {
                Value = new Dictionary<string, List<string>>
                {
                    { "username", new List<string> {"aUserName" } },
                    { "gibberish", new List<string> { "year of our lord 1822" } }
                }
            };

            //Act
            var result = _validator.Validate(extension);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("'gibberish' parameter is not supported for GetCollectionExtensible");
        }

        [TestMethod]
        public void Request_MissingUserName()
        {
            //Arrange
            var request = new CollectionRequest
            {
                UserName = null,
                BggRating = 5                
            };

            //Act
            var result = _validator.Validate(request);

            //assert    
            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.Should().Contain("Missing required element for CollectionRequest: userName");
        }
    }
}
