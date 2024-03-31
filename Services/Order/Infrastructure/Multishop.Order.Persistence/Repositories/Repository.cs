using Microsoft.EntityFrameworkCore;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Persistence.Repositories
{
    public class Repository<T>(OrderContext _context) : IRepository<T> where T : class
    {
        private DbSet<T> Table { get => _context.Set<T>(); }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await GetByIdAsync(id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await Table.ToListAsync();
        }

        public Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return Table.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
