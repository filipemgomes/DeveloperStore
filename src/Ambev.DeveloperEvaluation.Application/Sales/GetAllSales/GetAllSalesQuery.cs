using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesQuery : IRequest<GetAllSalesResult>
    {
        public bool OnlyActiveSales { get; set; }
    }

}