using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.Customer).NotEmpty();
            RuleFor(s => s.SaleItems).NotEmpty().Must(si => si.Count <= 20);
        }
    }
}
