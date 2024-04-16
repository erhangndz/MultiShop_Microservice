using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DataAccess.Abstract;

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

        public T TGetById(int id)
        {
            return genericDal.GetById(id);
        }

        public void TUpdate(T entity)
        {
            genericDal.Update(entity);
        }
    }
}
