using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Infrastructure.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AttemptsExceededException : Exception
    {
        public AttemptsExceededException()
        {

        }

        public AttemptsExceededException(string message)
            : base(message)
        {

        }

        public AttemptsExceededException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
