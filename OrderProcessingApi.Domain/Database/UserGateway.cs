namespace OrderProcessingApi.Domain.Database;

public class UserGateway : GatewayBase
{
    public string Auth0Id { get; set; }
    public virtual List<ProductGateway> Products { get; set; }
    public virtual IntegrationGateway Integration { get; set; }
}