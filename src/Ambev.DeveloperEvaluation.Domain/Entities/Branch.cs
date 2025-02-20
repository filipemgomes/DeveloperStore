using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Location { get; private set; } = string.Empty;
        public bool AllowsDiscounts { get; private set; }

        public Branch(string name, string location, bool allowsDiscounts)
        {
            Name = name;
            Location = location;
            AllowsDiscounts = allowsDiscounts;
        }

        public void UpdateBranch(string name, string location, bool allowsDiscounts)
        {
            Name = name;
            Location = location;
            AllowsDiscounts = allowsDiscounts;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new BranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
