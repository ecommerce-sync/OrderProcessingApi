using OrderProcessingApi.Domain.Integrations;

namespace OrderProcessingApi.Domain;

public class UserDto
{
    public int Id { get; init; }
    public string? Auth0Id { get; init; }
    public DateTime? DateLastModified { get; init; }
    public DateTime? DateCreated { get; init; }
}

public class IntegrationDto
{
    public WooIntegrationDto WooIntegration { get; set; }

}

public class WooIntegrationDto
{
    public int Id { get; set; }
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string Url { get; set; }
    public DateTime DateLastModified { get; set; }
    public DateTime DateCreated { get; set; }
}