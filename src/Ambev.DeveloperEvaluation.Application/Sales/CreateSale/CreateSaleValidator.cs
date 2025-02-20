using Ambev.DeveloperEvaluation.Application.Sales.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(s => s.SaleNumber).NotEmpty();
            RuleFor(s => s.BranchId).NotEmpty();

            RuleForEach(s => s.SaleItems).SetValidator(new SaleItemRequestValidator());
        }
    }
}
