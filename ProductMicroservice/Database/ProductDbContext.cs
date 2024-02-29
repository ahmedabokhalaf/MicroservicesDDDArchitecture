using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ProductAggregate;

namespace ProductMicroservice.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
