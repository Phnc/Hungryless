using Hungryless.Domain.Entities;

namespace Hungryless.Domain.Contracts.Services
{
    public interface ISuppliesService : IServiceBase<Supplies>
    {
        Task<IEnumerable<Supplies>> GetByCategory(string categoryName);
    }
}
