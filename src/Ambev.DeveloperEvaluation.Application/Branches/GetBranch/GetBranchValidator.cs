using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch
{
    public class GetBranchValidator : AbstractValidator<GetBranchQuery>
    {
        public GetBranchValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("Branch ID is required.");
        }
    }
}
