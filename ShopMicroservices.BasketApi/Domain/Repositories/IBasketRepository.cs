using ShopMicroservices.BasketApi.Application.Models;

namespace ShopMicroservices.BasketApi.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task DeleteBasket(string username);
        Task<ShoppingCart?> GetBasket(string username);
        Task<ShoppingCart?> UpdateBasket(ShoppingCart cart);
    }
}