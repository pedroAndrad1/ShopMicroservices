using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShopMicroservices.ProductApi.Domain.Models;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int PriceInCents { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string? Category { get; set; }
    public DateTime Created_at { get; init; }
}
