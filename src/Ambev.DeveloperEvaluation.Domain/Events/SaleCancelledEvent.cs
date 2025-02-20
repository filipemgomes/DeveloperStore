namespace Ambev.DeveloperEvaluation.Domain.Events
{
    using MediatR;

    public class SaleCancelledEvent : INotification
    {
        public Guid SaleId { get; }
        public string Customer { get; }
        public Guid BranchId { get; }
        public DateTime CancelledAt { get; } = DateTime.UtcNow;

        public SaleCancelledEvent(Guid saleId, string customer, Guid branchId)
        {
            SaleId = saleId;
            Customer = customer;
            BranchId = branchId;
        }
    }
}
