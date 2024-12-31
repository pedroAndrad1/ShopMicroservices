using MongoDB.Driver;
using ShopMicroservices.ProductApi.Application.Models;
using ShopMicroservices.ProductApi.Domain.Context;
using ShopMicroservices.ProductApi.Domain.Repositories;
using System.Xml.Linq;

namespace ShopMicroservices.ProductApi.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAppDbContext _appDbContext;

        public ProductRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateProduct(Product product)
        {
            await _appDbContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _appDbContext.Products.DeleteOneAsync(filterDefinition);
            
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, id);
            return await _appDbContext.Products.Find(filterDefinition).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _appDbContext.Products.Find(filterDefinition).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Category, name);
            return await _appDbContext.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _appDbContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
            var updateResult = await _appDbContext.Products.ReplaceOneAsync(filter: filterDefinition, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
