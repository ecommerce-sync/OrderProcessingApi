namespace OrderProcessingApi.Domain.Database;

public class UserGateway : GatewayBase
{
    public string Auth0Id { get; set; }
    public List<ProductGateway> Products { get; set; }
}