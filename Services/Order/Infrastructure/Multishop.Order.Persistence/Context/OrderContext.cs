using Microsoft.EntityFrameworkCore;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {

        public OrderContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
