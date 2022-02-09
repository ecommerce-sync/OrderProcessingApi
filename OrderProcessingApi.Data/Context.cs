using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderProcessingApi.Domain.Database;


namespace OrderProcessingApi.Data;

public class Context : DbContext
{
    private readonly IConfiguration _configuration;
    private DbSet<ProductGateway> Products { get; set; }
    private DbSet<UserGateway> Users { get; set; }
    private DbSet<PlatformGateway> Platforms { get; set; }
    private DbSet<BundleGateway> Bundles { get; set; }

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

        modelBuilder.Entity<ProductGateway>()
            .HasMany<BundleGateway>(p => p.Bundles)
            .WithMany(b => b.Products);

        modelBuilder.Entity<ProductGateway>()
            .HasMany<PlatformGateway>(p => p.Platforms)
            .WithMany(p => p.Products);
    }
}