using MassTransit;
using ShopMicroservices.MassTransitContracts.Contracts;

namespace ShopMicroservices.DiscountApi.Application.Consumers;

public class CreateDiscountToNewProductFaultConsumer : IConsumer<Fault<CreateDiscountToNewProduct>>
{

    private readonly ILogger<CreateDiscountToNewProductFaultConsumer> _logger;

    public CreateDiscountToNewProductFaultConsumer(ILogger<CreateDiscountToNewProductFaultConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Fault<CreateDiscountToNewProduct>> context)
    {
        _logger.LogError($"Falha ao criar um cupom para o produto {context.Message.Message.Name}");
        return Task.CompletedTask;
    }
}
