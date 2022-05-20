using System;
using System.IO;
using System.Reflection;

namespace Bgg.Net.Common.Tests.Infrastructure.Xml
{
    /// <summary>
    /// Test Class to aid in generating of XmlStrings and parsing them to XmlElements.
    /// </summary>
    public static class XmlGenerator
    {
        public static string GenerateResourceXml(string resourceName)
        {
            var stream = GetEmbeddedResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        private static Stream GetEmbeddedResourceStream(string resourceName)
        {
            var stream =  Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

            if (stream == null)
                throw new Exception("Unable to get Resource Stream");

            return stream;
        }       
    }
}

