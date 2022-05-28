using Bgg.Net.Common.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Infrastructure.Validation
{
    public class ThreadRequestValidator : RequestValidatorBase, IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(Extension extension)
        {
            throw new NotImplementedException();
        }
    }
}
