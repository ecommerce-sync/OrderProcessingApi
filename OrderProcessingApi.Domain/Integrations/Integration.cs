using OrderProcessingApi.Domain.IntegrationProfiles;

namespace OrderProcessingApi.Domain.Integrations;

public class Integration
{
    public int Id { get; set; }
    public WooIntegration WooIntegration { get; set; }
}