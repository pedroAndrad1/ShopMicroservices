namespace ShopMicroservices.ProductApi.Domain.Models;

public class Category
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
    public DateTime Created_at { get; init; }
}
