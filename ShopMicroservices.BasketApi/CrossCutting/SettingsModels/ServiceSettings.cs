namespace ShopMicroservices.BasketApi.CrossCutting.SettingsModels;

public record ServiceSettings
{
    public string ServiceName { get; set; } = string.Empty;
    public string ServiceHost {  get; set; } = string.Empty;
    public int ServicePort { get; set; }
    public string ServiceDiscoveryAddress { get; set; } = string.Empty;
    public string HealthCheckUrl { get; set; } = string.Empty ;
    public int HealthCheckIntervalSeconds { get; set; }
    public int HealthCheckTimeoutSeconds { get; set; }
}
