namespace Multishop.Cargo.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        IList<T> TGetAll();
    }
}
