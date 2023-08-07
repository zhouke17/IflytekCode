using System.Linq.Expressions;

namespace WebApi.Services
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsync();    
    }
}
