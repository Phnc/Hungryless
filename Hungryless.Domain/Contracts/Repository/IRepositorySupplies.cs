using Hungryless.Domain.Entities;

namespace Hungryless.Domain.Contracts.Repository
{
    public interface IRepositorySupplies : IRepositoryBase<Supplies>
    {
        Task<IEnumerable<Supplies>> GetByCategory(string categoryName);
    }
}
