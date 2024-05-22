using System.Linq.Expressions;

namespace Multishop.Cargo.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        IList<T> TGetAll();

        T TGetByFilter(Expression<Func<T, bool>> filter);

        IList<T> TGetFilteredList(Expression<Func<T, bool>> filter);
    }
}
