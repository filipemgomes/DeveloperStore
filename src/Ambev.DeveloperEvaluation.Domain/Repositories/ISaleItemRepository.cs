using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {
        Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId);
    }
}
