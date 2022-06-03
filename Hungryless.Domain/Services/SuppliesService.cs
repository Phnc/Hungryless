using Hungryless.Domain.Contracts.Repository;
using Hungryless.Domain.Contracts.Services;
using Hungryless.Domain.Entities;

namespace Hungryless.Domain.Services
{
    public class SuppliesService : BaseService<Supplies>, ISuppliesService
    {
        private IRepositorySupplies _db;

        public SuppliesService(IRepositorySupplies db) : base(db)
        {
            _db = db;
        }

        public Task<IEnumerable<Supplies>> GetByCategory(string categoryName)
        {
            return _db.GetByCategory(categoryName);
        }
    }
}
