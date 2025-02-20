using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

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

    public Sale(string saleNumber,  string customer, Guid branchId)
    {
        SaleNumber = saleNumber;
        SaleDate = DateTime.UtcNow;
        Customer = customer;
        BranchId = branchId;
        Status = SaleStatusEnum.Active;
        TotalAmount = 0;
    }

    public void CancelSale()
    {
        Status = SaleStatusEnum.Cancelled;
    }

    public void UpdateSale(string customer, Guid branchId)
    {
        Customer = customer;
        BranchId = branchId;

    }

    public void UpdateSaleItems(List<SaleItem> saleItems)
    {
        SaleItems = saleItems;
        TotalAmount = saleItems.Sum(item => item.TotalPrice);
    }

    public static decimal CalculateDiscount(int quantity)
    {
        if (quantity < 4)
            return 0m;
        if (quantity >= 4 && quantity <= 9)
            return 0.10m;
        if (quantity >= 10 && quantity <= 20)
            return 0.20m;

        return 0m; // A validação será feita no Validator
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
