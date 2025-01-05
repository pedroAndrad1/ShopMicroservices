namespace ShopMicroservices.DiscountApi.Domain.Models;

public interface ICoupon
{
    public int Id { get; init; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
}
