using ShopMicroservices.DiscountApi.Domain.Models;

namespace ShopMicroservices.DiscountApi.Application.Models
{
    public class Coupon : ICoupon
    {
        public int Id { get; init; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
