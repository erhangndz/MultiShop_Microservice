using Microsoft.EntityFrameworkCore;
using Multishop.Cargo.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DataAccess.Concrete
{
    public class CargoContext : DbContext
    {
        public CargoContext(DbContextOptions options): base(options) { }

        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }

       
    }
}
