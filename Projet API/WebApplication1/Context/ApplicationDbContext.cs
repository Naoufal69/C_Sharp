using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        optionBuilder.UseMySQL("server=127.0.0.1;Port=1234;database=api-dotnet;uid=root;pwd='';");
    }

    public DbSet<Product> products { get; set; }
}