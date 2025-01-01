using Microsoft.Extensions.Caching.Distributed;
using ShopMicroservices.BasketApi.Application.Models;
using ShopMicroservices.BasketApi.Domain.Repositories;
using System.Text.Json;

namespace ShopMicroservices.BasketApi.Application.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _cache;

    public BasketRepository(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<ShoppingCart?> GetBasket(string username)
    {
        var basket = await _cache.GetStringAsync(username);
        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonSerializer.Deserialize<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart?> UpdateBasket(ShoppingCart cart)
    {
        await _cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));

        return await GetBasket(cart.UserName);
    }

    public async Task DeleteBasket(string username)
    {
        await _cache.RemoveAsync(username);
    }
}
