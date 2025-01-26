using Microsoft.Extensions.Options;
using ShopMicroservices.DiscountApi.CrossCutting.SettingsModels;

namespace ShopMicroservices.ProductApi.CrossCutting;

public static class BootstrapExtensions
{
    public static ServiceSettings Bootstrap(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServiceSettings>(configuration.GetSection(nameof(ServiceSettings)));
        var serviceProvider = services.BuildServiceProvider();
        var iop = serviceProvider.GetService<IOptions<ServiceSettings>>();

        return iop!.Value;
    }
}
