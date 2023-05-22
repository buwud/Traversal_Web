using Microsoft.EntityFrameworkCore;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.DAL.Context
{
    public class GuestContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;initial catalog=TraversalDbAPI;integrated security=true;");
        }

        public DbSet<Guest> Guests { get; set; }
    }
}
