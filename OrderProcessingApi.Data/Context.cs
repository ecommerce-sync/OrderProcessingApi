using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderProcessingApi.Domain.Database;


namespace OrderProcessingApi.Data;

public class Context : DbContext
{
    private readonly IConfiguration _configuration;
    private DbSet<Product> Products { get; set; }
    private DbSet<User> Users { get; set; }
    private DbSet<Platform> Platforms { get; set; }
    private DbSet<Bundle> Bundles { get; set; }

    public Context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Context");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<Product>()
            .HasMany<Bundle>(p => p.Bundles)
            .WithMany(b => b.Products);

        modelBuilder.Entity<Product>()
            .HasMany<Platform>(p => p.Platforms)
            .WithMany(p => p.Products);
    }
}