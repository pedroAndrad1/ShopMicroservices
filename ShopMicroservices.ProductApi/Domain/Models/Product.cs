namespace ShopMicroservices.ProductApi.Domain.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int PriceInCents { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime Created_at { get; init; }
}
