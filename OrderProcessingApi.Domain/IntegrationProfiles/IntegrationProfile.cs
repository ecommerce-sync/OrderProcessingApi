namespace OrderProcessingApi.Domain.IntegrationProfiles;

public struct IntegrationProfile
{
    public int Id { get; set; }
    public WooIntegrationProfile WooIntegrationProfile { get; set; }
}