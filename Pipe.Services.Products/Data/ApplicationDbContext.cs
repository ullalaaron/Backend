using Microsoft.EntityFrameworkCore;
using Products.Data.Entities;
using Products.Data.EntitiesConfigurators;

namespace Products.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfigurator).Assembly);
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "The Bombster",
            Price = 999.00,
            ImageURL = ""
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "The Bombastic",
            Price = 1049.00,
            ImageURL = ""
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "The Gigastic",
            Price = 1199.00,
            ImageURL = ""
        });
    }
}