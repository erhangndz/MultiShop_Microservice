using Microsoft.EntityFrameworkCore;
using Multishop.Message.DataAccess.Entities;

namespace Multishop.Message.DataAccess.Context
{
    public class MessageContext:DbContext
    {

        public MessageContext(DbContextOptions options): base(options) { }

        public DbSet<UserMessage> UserMessages { get; set; }
      
    }
}
