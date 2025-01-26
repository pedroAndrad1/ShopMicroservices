using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;

namespace ShopMicroservices.GatewayApi.CrossCutting;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOcelot().AddConsul();

        return services;
    }
}
