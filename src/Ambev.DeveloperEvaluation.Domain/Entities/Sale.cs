using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; private set; } = string.Empty;
        public DateTime SaleDate { get; private set; }
        public string Customer { get; private set; } = string.Empty;
        public decimal TotalAmount { get; private set; }
        public SaleStatusEnum Status { get; private set; }
        public Guid BranchId { get; private set; }

        public virtual Branch Branch { get; private set; } = null!;
        public virtual List<SaleItem> SaleItems { get; private set; } = new List<SaleItem>();

        public Sale(string saleNumber, DateTime saleDate, string customer, decimal totalAmount, SaleStatusEnum status, Guid branchId, Branch branch, List<SaleItem> saleItems)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            Customer = customer;
            TotalAmount = totalAmount;
            Status = status;
            BranchId = branchId;
            Branch = branch;
            SaleItems = saleItems;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}