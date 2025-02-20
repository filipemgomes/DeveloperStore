using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .Matches(new Regex("^[a-zA-Z0-9 ]*$")).WithMessage("Product name can only contain letters, numbers, and spaces.")
                .Matches(new Regex("[a-zA-Z]"))
                .WithMessage("Product name must contain at least one letter.")
                .Must(name => !name.StartsWith(" ") && !name.EndsWith(" "))
                .WithMessage("Product name cannot start or end with a space.")
                .Must(name => !Regex.IsMatch(name, "  +"))
                .WithMessage("Product name cannot contain multiple consecutive spaces.");
        }
    }
}
