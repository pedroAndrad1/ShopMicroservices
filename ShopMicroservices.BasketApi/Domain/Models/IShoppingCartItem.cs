namespace ShopMicroservices.BasketApi.Domain.Models;

public interface IShoppingCartItem
{
    int PriceInCents { get; set; }
    string? ProductId { get; set; }
    string? ProductName { get; set; }
    int quantity { get; set; }
}