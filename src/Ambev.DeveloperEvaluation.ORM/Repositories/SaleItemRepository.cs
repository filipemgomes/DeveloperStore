using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId)
        {
            return await _context.SaleItems.Where(si => si.Id == saleId).ToListAsync();
        }
    }    
}
