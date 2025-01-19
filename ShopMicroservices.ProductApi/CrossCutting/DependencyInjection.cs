using Asp.Versioning;
using MassTransit;
using ShopMicroservices.MassTransitContracts.Contracts;
using ShopMicroservices.ProductApi.Application.Repositories;
using ShopMicroservices.ProductApi.Application.Services;
using ShopMicroservices.ProductApi.Domain.Context;
using ShopMicroservices.ProductApi.Domain.Repositories;
using ShopMicroservices.ProductApi.Domain.Services;
using ShopMicroservices.ProductApi.Infrastructure.Context;

namespace ShopMicroservices.ProductApi.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DB CONTEXT
        services.AddScoped<IAppDbContext, AppDbContext>();
        // REPOSITORIES
        services.AddScoped<IProductRepository, ProductRepository>();
        // VERSIONAMENTO
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
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
        });
        // SERVICES
        services.AddScoped<IBusService, BusService>();

        return services;
    }
}
