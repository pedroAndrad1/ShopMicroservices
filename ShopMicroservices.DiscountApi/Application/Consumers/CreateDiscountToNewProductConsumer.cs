using MassTransit;
using ShopMicroservices.DiscountApi.Application.Models;
using ShopMicroservices.DiscountApi.Domain.Repositories;
using ShopMicroservices.MassTransitContracts.Contracts;

namespace ShopMicroservices.DiscountApi.Application.Consumers;

public class CreateDiscountToNewProductConsumer : IConsumer<CreateDiscountToNewProduct>
{
    private readonly ILogger<CreateDiscountToNewProductConsumer> _logger;
    private readonly IDiscountRepository _repository;

    public CreateDiscountToNewProductConsumer(ILogger<CreateDiscountToNewProductConsumer> logger, IDiscountRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<CreateDiscountToNewProduct> context)
    {
        Coupon newCoupon = new()
        {
            ProductName = context.Message.Name,
            Description = context.Message.Description,
            Amount = 10,
        };

        await _repository.CreateDiscount(newCoupon);
        _logger.LogInformation($"Novo cupom! Produto {context.Message.Name}, {context.Message.Description}");
    }
}
