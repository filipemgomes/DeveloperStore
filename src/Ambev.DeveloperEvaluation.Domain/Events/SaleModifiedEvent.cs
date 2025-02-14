namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; }
        public DateTime ModifiedAt { get; }

        public SaleModifiedEvent(Guid saleId, DateTime modifiedAt)
        {
            SaleId = saleId;
            ModifiedAt = modifiedAt;
        }
    }
}
