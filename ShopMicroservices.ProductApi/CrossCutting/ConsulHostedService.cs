
using Consul;
using ShopMicroservices.ProductApi.CrossCutting.SettingsModels;

namespace ShopMicroservices.ProductApi.CrossCutting;

public class ConsulHostedService : IHostedService
{
    private readonly IConsulClient _consulClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ConsulHostedService> _logger;

    public ConsulHostedService(IConsulClient consulClient, IConfiguration configuration, ILogger<ConsulHostedService> logger)
    {
        _consulClient = consulClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var serviceConfig = _configuration.GetSection("ServiceSettings").Get<ServiceSettings>();
        var registration = new AgentServiceRegistration
        {
            ID = serviceConfig!.ServiceName,
            Name = serviceConfig.ServiceName,
            Address = serviceConfig.ServiceHost,
            Port = serviceConfig.ServicePort,
        };

        //var check = new AgentServiceCheck
        //{
        //    HTTP = serviceConfig.HealthCheckUrl,
        //    Interval = TimeSpan.FromSeconds(serviceConfig.HealthCheckIntervalSeconds),
        //    Timeout = TimeSpan.FromSeconds(serviceConfig.HealthCheckTimeoutSeconds)
        //};

        //registration.Checks = new[] { check };

        _logger.LogInformation($"Registrando service no Consul: {registration.Name}");

        await _consulClient.Agent.ServiceDeregister(registration.ID, cancellationToken);
        await _consulClient.Agent.ServiceRegister(registration, cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        var serviceConfig = _configuration.GetSection("ServiceSettings").Get<ServiceSettings>();
        var registration = new AgentServiceRegistration { ID = serviceConfig!.ServiceName };

        _logger.LogInformation($"Desregistrando service no Consul: {registration.ID}");

        await _consulClient.Agent.ServiceDeregister(registration.ID, cancellationToken);
    }
}
