namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ItemCancelledEvent
    {
        public Guid SaleItemId { get; }
        public Guid SaleId { get; }
        public DateTime CancelledAt { get; }

        public ItemCancelledEvent(Guid saleItemId, Guid saleId, DateTime cancelledAt)
        {
            SaleItemId = saleItemId;
            SaleId = saleId;
            CancelledAt = cancelledAt;
        }
    }
}
