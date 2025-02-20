namespace Ambev.DeveloperEvaluation.Domain.Events
{
    using MediatR;

    public class SaleCreatedEvent : INotification
    {
        public Guid SaleId { get; }
        public DateTime SaleDate { get; } = DateTime.UtcNow;
        public string Customer { get; }

        public SaleCreatedEvent(Guid saleId, string customer)
        {
            SaleId = saleId;
            Customer = customer;
        }
    }
}
