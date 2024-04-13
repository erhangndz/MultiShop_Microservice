using Multishop.Basket.Models;

namespace Multishop.Basket.Services
{
    public interface IBasketService<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task Delete(int id);
        Task Create(T entity);
        Task Update(T entity);
    }
}
