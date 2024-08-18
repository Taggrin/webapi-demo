using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Entities;

namespace WebAPIDemo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed demo data
            modelBuilder.Entity<Product>().HasData(
                new Product { ID = 1, Description = "Band-aid", Price = 5M, Modified = DateTime.UtcNow },
                new Product { ID = 2, Description = "Thermometer", Price = 10.50M, Modified = DateTime.UtcNow },
                new Product { ID = 3, Description = "Blood Pressure Monitor", Price = 39.99M, Modified = DateTime.UtcNow },
                new Product { ID = 4, Description = "Gauze Pads", Price = 3M, Modified = DateTime.UtcNow },
                new Product { ID = 5, Description = "Stethoscope", Price = 28M, Modified = DateTime.UtcNow }
            );
        }
    }
}
