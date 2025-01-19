using MassTransit;
using ShopMicroservices.ProductApi.Domain.Services;

namespace ShopMicroservices.ProductApi.Application.Services;

public class BusService : IBusService
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public BusService(IBus bus, IConfiguration configuration)
    {
        _bus = bus;
        _configuration = configuration;
    }

    public async Task Send(string queue, object message)
    {
        Uri uri = new($"rabbitmq://{_configuration.GetValue<string>("MassTransitSettings:RabbitMQHost")}/{queue}");
        var endpoint = await _bus.GetSendEndpoint(uri);
        await endpoint.Send(message);
    }
}
