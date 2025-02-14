namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCancelledEvent
    {
        public Guid SaleId { get; }
        public DateTime CancelledAt { get; }

        public SaleCancelledEvent(Guid saleId, DateTime cancelledAt)
        {
            SaleId = saleId;
            CancelledAt = cancelledAt;
        }
    }
}
