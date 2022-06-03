using Hungryless.Domain.Entities;

namespace Hungryless.Domain.Contracts.Services
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<TEntity> Get(Guid id);
        Task<IReadOnlyList<TEntity>> GetAll();
    }
}
