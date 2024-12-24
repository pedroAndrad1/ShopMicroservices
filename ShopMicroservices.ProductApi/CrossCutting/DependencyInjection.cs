using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductApi.Application.Repositories;
using ShopMicroservices.ProductApi.Domain.Context;
using ShopMicroservices.ProductApi.Domain.Repositories;
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

        return services;
    }
}
