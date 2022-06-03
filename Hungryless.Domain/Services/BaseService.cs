using Hungryless.Domain.Contracts.Repository;
using Hungryless.Domain.Contracts.Services;
using Hungryless.Domain.Entities;

namespace Hungryless.Domain.Services
{
    public class BaseService<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryBase<TEntity> _db;

        public BaseService(IRepositoryBase<TEntity> db)
        {
            _db = db;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            return _db.Add(entity);
        }

        public Task<bool> Delete(Guid id)
        {
            return _db.Delete(id);
        }

        public Task<TEntity> Get(Guid id)
        {
            return _db.Get(id);
        }

        public Task<IReadOnlyList<TEntity>> GetAll()
        {
            return _db.GetAll();
        }

        public Task<bool> Update(TEntity entity)
        {
            return _db.Update(entity);
        }
    }
}
