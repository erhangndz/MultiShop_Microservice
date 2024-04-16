using System.Linq.Expressions;

namespace Multishop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
