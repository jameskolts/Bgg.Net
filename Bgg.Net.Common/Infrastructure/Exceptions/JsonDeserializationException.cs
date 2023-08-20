using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Infrastructure.Exceptions
{
    /// <summary>
    /// Represents an error that occurs during json deserialization.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class JsonDeserializationException : Exception
    {

        public JsonDeserializationException()
        {

        }

        public JsonDeserializationException(string message)
            : base(message)
        {

        }

        public JsonDeserializationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
