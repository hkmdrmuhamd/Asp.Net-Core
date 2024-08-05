using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product() { id = 1, ProductName = "Iphone12", Price = 30000, IsActive = false });
            modelBuilder.Entity<Product>().HasData(new Product() { id = 2, ProductName = "Iphone13", Price = 40000, IsActive = true });
            modelBuilder.Entity<Product>().HasData(new Product() { id = 3, ProductName = "Iphone14", Price = 50000, IsActive = false });
            modelBuilder.Entity<Product>().HasData(new Product() { id = 4, ProductName = "Iphone15", Price = 60000, IsActive = true });
        }

        public DbSet<Product> Products { get; set; }
    }
}