using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ShopMicroservices.ProductApi.Application.Models;
using ShopMicroservices.ProductApi.Domain.Context;

namespace ShopMicroservices.ProductApi.Infrastructure.Context;

public class AppDbContext : IAppDbContext
{
    public IMongoCollection<Product> Products { get; }

    public AppDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        AppDbContextSeed.SeedData(Products);
    }
}

