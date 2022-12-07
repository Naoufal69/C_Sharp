using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> products { get; set; }
    public DbSet<Seller> sellers { get; set; }
}