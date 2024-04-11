using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
