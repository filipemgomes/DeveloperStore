using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Common
{
    public class SaleItemRequestValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemRequestValidator()
        {
            RuleFor(si => si.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

            RuleFor(si => si.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
