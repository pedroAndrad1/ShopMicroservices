using ShopMicroservices.BasketApi.Application.Repositories;
using ShopMicroservices.BasketApi.Domain.Repositories;

namespace ShopMicroservices.BasketApi.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options => {
            options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
        });
        services.AddScoped<IBasketRepository, BasketRepository>();

        return services;
    }
}
