using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SampleBlazorApp.Data;

public class SampleBlazorAppContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
{
    public SampleBlazorAppContext(DbContextOptions<SampleBlazorAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
