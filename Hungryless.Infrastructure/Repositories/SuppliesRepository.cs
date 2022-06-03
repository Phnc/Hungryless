using Hungryless.Domain.Contracts.Repository;
using Hungryless.Domain.Entities;
using Hungryless.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hungryless.Infrastructure.Repositories
{
    public class SuppliesRepository : RepositoryBase<Supplies>, IRepositorySupplies
    {
        public SuppliesRepository(HungrylessDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Supplies>> GetByCategory(string categoryName)
        {
            var supplies = await _db.Supplies.Where(s => s.Category == categoryName).ToListAsync();
            return supplies;
        }
    }
}
