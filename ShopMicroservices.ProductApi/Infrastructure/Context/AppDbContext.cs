using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductApi.Domain.Models;

namespace ShopMicroservices.ProductApi.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Config Categories Table
        ConfigTables(modelBuilder);
        PopulateTables(modelBuilder);
    }

    private static void ConfigTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        // Config Products Table
        modelBuilder.Entity<Product>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        modelBuilder.Entity<Product>()
            .Property(c => c.Description)
            .HasMaxLength(255);
        modelBuilder.Entity<Product>()
            .Property(c => c.ImageUrl)
            .HasMaxLength(255);
    }

    private static void PopulateTables(ModelBuilder modelBuilder)
    {
        Guid categoria0Id = Guid.NewGuid();
        Guid categoria1Id = Guid.NewGuid();
        Guid categoria2Id = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = categoria0Id, Name = "Bebidas", Created_at = DateTime.Now },
            new Category { Id = categoria1Id, Name = "Salgados", Created_at = DateTime.Now },
            new Category { Id = categoria2Id, Name = "Doces", Created_at = DateTime.Now }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = categoria0Id,
                Name = "Suco de caju",
                Description = "da fruta",
                PriceInCents = 8 * 100,
                Stock = 100,
                ImageUrl = "suco_de_caju.jpg",
                Created_at = DateTime.Now
            },
             new Product
             {
                 Id = Guid.NewGuid(),
                 CategoryId = categoria1Id,
                 Name = "Joelho",
                 Description = "queijo e presunto",
                 PriceInCents = 6 * 100,
                 Stock = 100,
                 ImageUrl = "joelho.jpg",
                 Created_at = DateTime.Now
             },
              new Product
              {
                  Id = Guid.NewGuid(),
                  CategoryId = categoria2Id,
                  Name = "Sorvete",
                  Description = "de chocolate",
                  PriceInCents = 10 * 100,
                  Stock = 100,
                  ImageUrl = "sorvete_de_chocolate.jpg",
                  Created_at = DateTime.Now
              }
        );
    }
}

