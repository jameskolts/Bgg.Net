using Bgg.Net.Common.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace Bgg.Net.Common.Validation
{
    public class PlayRequestValidator : IPlayRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var playRequest = request as PlaysRequest;
            var validationResult = new ValidationResult();

            if (string.IsNullOrWhiteSpace(playRequest.UserName) && !playRequest.Id.HasValue)
            {
                validationResult.Errors.Add("Missing required element. Either username or id is required");
            }

            if (!string.IsNullOrWhiteSpace(playRequest.UserName) && playRequest.Id.HasValue)
            {
                validationResult.Errors.Add("Only one of 'username' or 'id' is allowed for PlaysRequest");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }

        public ValidationResult Validate(LogPlayRequest request)
        {
            var validationResult = new ValidationResult();
            var dataAnnotationValidationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            var dataAnnotationsAreValid =  Validator.TryValidateObject(request, new ValidationContext(request), dataAnnotationValidationResults, true);

            if (!dataAnnotationsAreValid)
            {
                validationResult.Errors.AddRange(dataAnnotationValidationResults.Select(x => x.ErrorMessage));
            }

            //TODO: Examine if there are other valid types.
            if (request.ObjectType != "thing")
            {
                validationResult.Errors.Add($"Invalid type: {request.ObjectType}.");
            }

            //TODO: Examine if there are other valid actions.
            if (request.Action != "save")
            {
                validationResult.Errors.Add($"Invalid action: {request.Action}.");
            }

            return validationResult;
        }
    }
}
