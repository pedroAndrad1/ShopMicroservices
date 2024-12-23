using Microsoft.EntityFrameworkCore;
using ShopMicroservices.ProductApi.Infrastructure.Context;

namespace ShopMicroservices.ProductApi.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DB CONTEXT
        var mysqlConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString));
        });

        return services;
    }
}
