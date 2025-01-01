using ShopMicroservices.BasketApi.Domain.Models;

namespace ShopMicroservices.BasketApi.Application.Models;

public class ShoppingCartItem : IShoppingCartItem
{
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
    public int quantity { get; set; }
    public int PriceInCents { get; set; }
}
