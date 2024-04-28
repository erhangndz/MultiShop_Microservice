using Microsoft.EntityFrameworkCore;
using Multishop.Comment.Entities;

namespace Multishop.Comment.Context
{
    public class CommentContext:DbContext
    {

        public CommentContext(DbContextOptions options):base(options){}

        public DbSet<UserComment> UserComments { get; set; }
    }
}
