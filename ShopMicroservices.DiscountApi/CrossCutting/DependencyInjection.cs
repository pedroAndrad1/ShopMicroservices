using MassTransit;
using ShopMicroservices.DiscountApi.Application.Repositories;
using ShopMicroservices.DiscountApi.Domain.Repositories;

namespace ShopMicroservices.BasketApi.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IDiscountRepository, DiscountRepository>();

        // MASS TRANSIT
        services.AddMassTransit(options =>
        {
            options.UsingRabbitMq((context, config) =>
            {
                config.Host(
                    configuration.GetValue<string>("MassTransitSettings:RabbitMQHost"),
                    "/",
                    host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    }
                );

                config.ConfigureEndpoints(context);
            });

            options.AddConsumer<CreateDiscountToNewProductConsumer>();
        });

        return services;
    }
}
