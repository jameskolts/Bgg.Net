using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Infrastructure.Exceptions
{
    /// <summary>
    /// Represents an error that occurs during xml deserialization.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class XmlDeserializationException : Exception
    {
        public XmlDeserializationException()
        {

        }

        public XmlDeserializationException(string message)
            : base(message)
        {

        }

        public XmlDeserializationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
