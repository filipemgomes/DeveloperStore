namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent
    {
        public Guid SaleId { get; }
        public DateTime SaleDate { get; }
        public string Customer { get; }

        public SaleCreatedEvent(Guid saleId, DateTime saleDate, string customer)
        {
            SaleId = saleId;
            SaleDate = saleDate;
            Customer = customer;
        }
    }
}
