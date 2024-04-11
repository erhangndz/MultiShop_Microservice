using Microsoft.EntityFrameworkCore;
using Multishop.Cargo.DataAccess.Abstract;
using Multishop.Cargo.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DataAccess.Repositories
{
    public class GenericRepository<T>(CargoContext _context) : IGenericDal<T> where T : class
    {
        private DbSet<T> Table { get => _context.Set<T>(); }
        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = GetById(id);
            _context.Remove(value);
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
