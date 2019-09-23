using iia.contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace iia.DataService
{
    public class DataContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=iiadev;User=root;Password=root123");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}