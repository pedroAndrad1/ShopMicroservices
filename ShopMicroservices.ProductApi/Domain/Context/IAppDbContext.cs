using MongoDB.Driver;
using ShopMicroservices.ProductApi.Domain.Models;

namespace ShopMicroservices.ProductApi.Domain.Context;

public interface IAppDbContext
{
    public IMongoCollection<Product> Products { get; }
}
