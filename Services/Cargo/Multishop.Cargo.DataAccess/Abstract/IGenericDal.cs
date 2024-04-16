namespace Multishop.Cargo.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
    }
}
