namespace ShopMicroservices.ProductApi.Domain.Services;

public interface IBusService
{
    Task Send(string queue, object message);
}