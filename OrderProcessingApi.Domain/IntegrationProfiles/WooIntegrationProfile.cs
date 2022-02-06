namespace OrderProcessingApi.Domain.IntegrationProfiles;

public struct WooIntegrationProfile : IIntegrationProfile
{
    public int Id { get; set; }
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string Url { get; set; }
}