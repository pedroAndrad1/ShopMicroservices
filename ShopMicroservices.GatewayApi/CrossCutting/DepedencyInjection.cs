using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;

namespace ShopMicroservices.GatewayApi.CrossCutting;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOcelot().AddConsul<CustomConsulServiceBuilder>();
        //services.AddOcelot();


        return services;
    }

    public static IConfigurationBuilder AddOcelotJson(this IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("ocelot.json",false);
        //configuration.AddJsonFile("ocelot.Development.json",false);

        return configuration;
    }
}
