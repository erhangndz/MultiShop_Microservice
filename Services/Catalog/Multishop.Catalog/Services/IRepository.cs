using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Services
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);

        Task<long> GetCountAsync();

        Task<decimal> GetAvgValueAsync();
    }
}
