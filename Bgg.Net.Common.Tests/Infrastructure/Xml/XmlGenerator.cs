using System.Xml;
using System.IO;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{   
    /// <summary>
    /// Test Class to aid in generating of XmlStrings and parsing them to XmlElements.
    /// </summary>
    public static class XmlGenerator
    {
        private const string BoardGameFilePath = "C:\\Users\\jkolt\\source\\repos\\BggNet\\Bgg.Net.Common.Tests\\TestFiles\\BoardGameXml.xml";

        public static XmlElement GenerateThingXmlElement()
        {

            var document = new XmlDocument();
            document.LoadXml(GenerateBoardGameXmlString());

            if (document.DocumentElement != null)
            {
                return document.DocumentElement;
            }
            else
            {
                throw new System.Exception("Unable to generate test XML");
            }
        }

        public static string GenerateBoardGameXmlString()
        {
            return File.ReadAllText(BoardGameFilePath);
        }
    }
}

