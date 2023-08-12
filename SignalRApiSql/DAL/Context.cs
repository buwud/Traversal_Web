using Microsoft.EntityFrameworkCore;

namespace SignalRApiSql.DAL
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
