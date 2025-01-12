using ShopMicroservices.DiscountApi.Application.Repositories;
using ShopMicroservices.DiscountApi.Domain.Repositories;

namespace ShopMicroservices.BasketApi.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IDiscountRepository, DiscountRepository>();
        return services;
    }
}
