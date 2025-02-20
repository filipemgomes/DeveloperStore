using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleValidator()
        {
            RuleFor(s => s.Customer)
                .NotEmpty().WithMessage("Customer is required.");

            RuleFor(s => s.BranchId)
                .NotEmpty().WithMessage("BranchId is required.");

            RuleForEach(s => s.SaleItems).SetValidator(new UpdateSaleItemValidator());
        }

    }
}