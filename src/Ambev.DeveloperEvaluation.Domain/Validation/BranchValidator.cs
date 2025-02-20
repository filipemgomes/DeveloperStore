using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name is required.");

            RuleFor(b => b.Location)
                .NotEmpty().WithMessage("Branch location is required.");

            RuleFor(b => b.AllowsDiscounts)
                .NotNull().WithMessage("AllowsDiscounts must be defined as true or false.");
        }
    }
}
