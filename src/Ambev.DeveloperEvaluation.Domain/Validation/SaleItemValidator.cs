using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(si => si.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(si => si.UnitPrice).GreaterThan(0);
            RuleFor(si => si.TotalPrice).GreaterThan(0);

        }
    }
    }
