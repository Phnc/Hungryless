namespace Hungryless.Domain.Contracts.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<TEntity> Get(Guid id);
        Task<IReadOnlyList<TEntity>> GetAll();
    }
}
