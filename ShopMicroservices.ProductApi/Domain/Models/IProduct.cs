
namespace ShopMicroservices.ProductApi.Domain.Models
{
    public interface IProduct
    {
        string? Id { get; init; }
        string? Category { get; set; }
        DateTime Created_at { get; init; }
        string? Description { get; set; }
        string? ImageUrl { get; set; }
        string Name { get; set; }
        int PriceInCents { get; set; }
        long Stock { get; set; }
    }
}