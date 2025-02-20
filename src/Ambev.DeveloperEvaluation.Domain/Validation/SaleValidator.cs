using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.SaleNumber).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Customer).NotEmpty().MaximumLength(100);
            RuleFor(s => s.TotalAmount).GreaterThan(0);
            RuleFor(s => s.Status).IsInEnum();
        }
    }
}
