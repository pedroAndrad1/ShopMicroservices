using MongoDB.Driver;
using ShopMicroservices.ProductApi.Application.Models;

namespace ShopMicroservices.ProductApi.Domain.Context;

public interface IAppDbContext
{
    public IMongoCollection<Product> Products { get; }
}
