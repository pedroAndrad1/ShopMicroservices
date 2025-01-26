﻿using Consul;
using ShopMicroservices.ProductApi.CrossCutting.SettingsModels;

namespace ShopMicroservices.ProductApi.CrossCutting;

public static class ConsulConfigExtensions
{
    public static IServiceCollection AddConsulSettings(this IServiceCollection services, ServiceSettings serviceSettings, IConfiguration configuration)
    {
        services.AddSingleton<IConsulClient, ConsulClient>(_ =>
            new ConsulClient(consulConfig => 
                consulConfig.Address = new Uri(serviceSettings.ServiceDiscoveryAddress)
            )
        );
        services.AddSingleton<IHostedService, ConsulHostedService>();
        services.Configure<ServiceSettings>(configuration.GetSection("ServiceSettings"));

        return services;
    }
}