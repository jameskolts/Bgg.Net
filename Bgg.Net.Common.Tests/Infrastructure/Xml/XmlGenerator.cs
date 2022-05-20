using System.IO;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    /// <summary>
    /// Test Class to aid in generating of XmlStrings and parsing them to XmlElements.
    /// </summary>
    public static class XmlGenerator
    {
        private const string boardGameFilePath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\BoardGameXml.xml";
        private const string multipleItemFilePath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\MultipleItemXml.xml";
        private const string familyFilePath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\FamilyXml.xml";
        private const string forumPath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\ForumXml.xml";
        private const string forumListPath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\ForumListXml.xml";
        private const string threadPath = @"C:\Users\jkolt\source\repos\BggNet\Bgg.Net.Common.Tests\TestFiles\ThreadXml.xml";

        public static string GenerateBoardGameXmlString()
        {
            return File.ReadAllText(boardGameFilePath);
        }

        public static string GenerateMultipleItemXmlString()
        {
            return File.ReadAllText(multipleItemFilePath);
        }

        public static string GenerateFamilyXmlString()
        {
            return File.ReadAllText(familyFilePath);
        }

        public static string GenerateForumXmlString()
        {
            return File.ReadAllText(forumPath);
        }

        public static string GenerateForumListXmlString()
        {
            return File.ReadAllText(forumListPath);
        }

        public static string GenerateThreadXmlString()
        {
            return File.ReadAllText(threadPath);
        }
    }
}

