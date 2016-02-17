using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Infraestructure.Repositories
{
    public class RepositoryEf<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public RepositoryEf(DbContext ctx)
        {
            _dbContext = ctx;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            
        }

        public int Insert(TEntity entity)
        {
            using (_dbContext)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
                _dbContext.Set<TEntity>().Add(entity);
                return _dbContext.SaveChanges();
            }
        }

        public IQueryable<TEntity> QueryAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<int> Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<TEntity>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public  int SaveChanges()
        {
            return  _dbContext.SaveChanges();
        }
    }
}
