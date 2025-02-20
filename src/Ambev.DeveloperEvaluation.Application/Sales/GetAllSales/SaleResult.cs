namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class SaleResult
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}