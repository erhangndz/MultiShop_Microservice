using Microsoft.EntityFrameworkCore;
using Multishop.Images.Entities;

namespace Multishop.Images.Context
{
    public class ImagesContext:DbContext
    {
        public ImagesContext(DbContextOptions options):base(options)
        {
            
        }


        public DbSet<ImageDrive> ImageDrives { get; set; }
    }
}
