using Microsoft.Extensions.Configuration;

namespace OrderProcessingApi.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfiguration _configuration;

    public ConfigurationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public WooConfiguration WooConfigurations => new()
    {
        GetProductsEndpoint = GetWooConfiguration<string>("GetProductsEndpoint")
    };

    private T GetSetting<T>(string key)
    {
        return (T)Convert.ChangeType(_configuration.GetValue<string>(key), typeof(T));
    }

    private T GetWooConfiguration<T>(string key)
    {
        return (T)Convert.ChangeType(
            _configuration.GetSection("EndpointConfigurations").GetSection("WooConfigurations").GetValue<string>(key),
            typeof(T));
    }
}

public class WooConfiguration
{
    public string GetProductsEndpoint { get; set; }
}