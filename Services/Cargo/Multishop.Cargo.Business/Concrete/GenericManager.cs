using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Multishop.Cargo.Business.Concrete
{
    public class GenericManager<T>(IGenericDal<T> genericDal) : IGenericService<T> where T : class
    {
        public void TCreate(T entity)
        {
            genericDal.Create(entity);
        }

        public void TDelete(int id)
        {
            genericDal.Delete(id);
        }

        public IList<T> TGetAll()
        {
            return genericDal.GetAll();
        }

        public T TGetByFilter(Expression<Func<T, bool>> filter)
        {
           return genericDal.GetByFilter(filter);
        }

        public T TGetById(int id)
        {
            return genericDal.GetById(id);
        }

        public IList<T> TGetFilteredList(Expression<Func<T, bool>> filter)
        {
           return genericDal.GetFilteredList(filter);
        }

        public void TUpdate(T entity)
        {
            genericDal.Update(entity);
        }
    }
}
