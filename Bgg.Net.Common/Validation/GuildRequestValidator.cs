using Bgg.Net.Common.Models.Requests;

namespace Bgg.Net.Common.Validation
{
    public class GuildRequestValidator : IRequestValidator
    {
        public ValidationResult Validate(BggRequest request)
        {
            var guildRequest = request as GuildRequest;
            var validationResult = new ValidationResult();

            if (guildRequest.Id == default)
            {
                validationResult.Errors.Add("Missing required element for GuildRequest: id");
            }

            validationResult.IsValid = !validationResult.Errors.Any();

            return validationResult;
        }
    }
}
