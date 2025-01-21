using ShopMicroservices.DiscountApi.Application.Models;

namespace ShopMicroservices.DiscountApi.Domain.Repositories;

public interface IDiscountRepository
{
    Task<Coupon?> GetDiscount(string productName);
    Task<bool> CreateDiscount(Coupon coupon);
    Task<bool> UpdateDiscount(Coupon coupon);
    Task<bool> DeleteDiscount(string productName);
    Task InitializeDb();
}
