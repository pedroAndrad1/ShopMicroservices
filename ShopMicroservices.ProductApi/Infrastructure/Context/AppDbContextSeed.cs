using MongoDB.Driver;
using ShopMicroservices.ProductApi.Domain.Models;

namespace ShopMicroservices.ProductApi.Infrastructure.Context;

public static class AppDbContextSeed
{
    public static void SeedData(IMongoCollection<Product> collection)
    {
        var hasCollectionData = collection.Find(p => true).Any();
        if (hasCollectionData)
        {
            collection.InsertMany(CreateSeed());
        }
    }

    private static IEnumerable<Product> CreateSeed()
    {
        return new List<Product>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Suco de caju",
                Description = "da fruta",
                PriceInCents = 8 * 100,
                Stock = 100,
                ImageUrl = "suco_de_caju.jpg",
                Created_at = DateTime.Now,
                Category = "Bebidas"
            },
             new()
             {
                 Id = Guid.NewGuid(),
                 Name = "Joelho",
                 Description = "queijo e presunto",
                 PriceInCents = 6 * 100,
                 Stock = 100,
                 ImageUrl = "joelho.jpg",
                 Created_at = DateTime.Now,
                 Category = "Salgados"
             },
              new() {
                  Id = Guid.NewGuid(),
                  Name = "Sorvete",
                  Description = "de chocolate",
                  PriceInCents = 10 * 100,
                  Stock = 100,
                  ImageUrl = "sorvete_de_chocolate.jpg",
                  Created_at = DateTime.Now,
                  Category = "Doces"
              }
        };
    }
}
