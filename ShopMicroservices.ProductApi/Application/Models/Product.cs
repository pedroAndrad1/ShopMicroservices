using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ShopMicroservices.ProductApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopMicroservices.ProductApi.Application.Models;

public class Product : IProduct
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public int PriceInCents { get; set; }
    public string? Description { get; set; }
    [Required]
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public string? Category { get; set; }
    public DateTime Created_at { get; init; }
}
