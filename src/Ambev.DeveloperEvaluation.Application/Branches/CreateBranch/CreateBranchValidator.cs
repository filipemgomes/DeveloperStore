using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name is required.")
                .Matches(new Regex("^[a-zA-Z0-9 ]*$")).WithMessage("Branch name can only contain letters, numbers, and spaces.")
                .Must(name => !name.StartsWith(" ") && !name.EndsWith(" "))
                .WithMessage("Branch name cannot start or end with a space.")
                .Must(name => !Regex.IsMatch(name, "  +"))
                .WithMessage("Branch name cannot contain multiple consecutive spaces.");

            RuleFor(b => b.Location)
                .NotEmpty().WithMessage("Branch location is required.")
                .Must(location => !location.StartsWith(" ") && !location.EndsWith(" "))
                .WithMessage("Branch location cannot start or end with a space.")
                .Must(location => !Regex.IsMatch(location, "  +"))
                .WithMessage("Branch location cannot contain multiple consecutive spaces.");
        }
    }
}
