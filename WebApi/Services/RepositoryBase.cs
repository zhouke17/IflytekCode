using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApi.Services
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T>, IRepositoryBase2<T, TId> where T : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IRepositoryBase<T>
        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_dbContext.Set<T>().AsEnumerable());
        }

        public Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return Task.FromResult(_dbContext.Set<T>().Where(condition).AsEnumerable());
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        #endregion



        #region IRepositoryBase2<T,TId>
        public async Task<T> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExistAsync(TId id)
        {
            return await _dbContext.Set<T>().FindAsync(id) != null;
        }
        #endregion

    }
}
