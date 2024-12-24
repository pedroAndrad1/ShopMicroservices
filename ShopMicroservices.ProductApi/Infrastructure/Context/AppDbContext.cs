using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ShopMicroservices.ProductApi.Domain.Context;
using ShopMicroservices.ProductApi.Domain.Models;

namespace ShopMicroservices.ProductApi.Infrastructure.Context;

public class AppDbContext : IAppDbContext
{
    public IMongoCollection<Product> Products { get; }

    public AppDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        AppDbContextSeed.SeedData(Products);
    }
}

