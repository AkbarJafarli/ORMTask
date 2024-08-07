using Microsoft.EntityFrameworkCore;
using ORMTask.Models;

namespace ORMTask.Contexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product>Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AKBAR\\SQLEXPRESS;Database=PB303GroupORMDb;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
