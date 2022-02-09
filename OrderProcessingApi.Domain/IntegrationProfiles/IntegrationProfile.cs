namespace OrderProcessingApi.Domain.IntegrationProfiles;

public class IntegrationProfile
{
    public int Id { get; set; }
    public int Auth0Id { get; set; }
    public WooIntegrationProfile WooIntegrationProfile { get; set; }
}