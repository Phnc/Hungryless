using Hungryless.Domain.Contracts.Repository;
using Hungryless.Domain.Entities;
using Hungryless.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hungryless.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly HungrylessDbContext _db;

        public RepositoryBase(HungrylessDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await _db.Set<TEntity>().FindAsync(id);
                _db.Set<TEntity>().Remove(entity);
                await _db.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}; Stacktrace: {ex.StackTrace}");
                return false;
            }            
        }

        public async Task<TEntity> Get(Guid id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public async Task<IReadOnlyList<TEntity>> GetAll()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _db.Set<TEntity>().Update(entity);
                await _db.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}; Stacktrace: {ex.StackTrace}");
                return false;
            }            
        }
    }
}
