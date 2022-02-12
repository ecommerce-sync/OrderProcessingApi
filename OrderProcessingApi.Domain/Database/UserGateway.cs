namespace OrderProcessingApi.Domain.Database;

public class UserGateway : GatewayBase
{
    public UserGateway()
    {
        Integrations = new List<IntegrationGateway>();
    }
    public string Auth0Id { get; set; }
    public virtual List<ProductGateway> Products { get; set; }
    public virtual ICollection<IntegrationGateway> Integrations { get; set; }
}