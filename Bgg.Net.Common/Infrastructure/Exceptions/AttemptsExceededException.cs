using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Infrastructure.Exceptions
{
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
