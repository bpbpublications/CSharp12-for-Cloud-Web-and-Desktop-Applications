using Microsoft.EntityFrameworkCore;

namespace WebAppEFCoreCodeFirst.Database
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
