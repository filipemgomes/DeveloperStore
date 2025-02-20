using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        public Guid SaleId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public Guid BranchId { get; set; }
        public List<UpdateSaleItemCommand> SaleItems { get; set; } = new();
    }
}
