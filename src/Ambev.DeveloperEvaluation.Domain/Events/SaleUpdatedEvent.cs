namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleUpdatedEvent
    {
        public Guid SaleId { get; }
        public DateTime ModifiedAt { get; }

        public SaleUpdatedEvent(Guid saleId, DateTime modifiedAt)
        {
            SaleId = saleId;
            ModifiedAt = modifiedAt;
        }
    }
}
