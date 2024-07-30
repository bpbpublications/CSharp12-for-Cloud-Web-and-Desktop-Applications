using Microsoft.EntityFrameworkCore;
namespace SqlServerWebApp.Database
{
    public class SqlServerDBContext : DbContext
    {
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options)
        : base(options)
        {
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }
    }
}
