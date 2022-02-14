namespace OrderProcessingApi.Domain.Database;

public class ProductGateway : GatewayBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public UserGateway User { get; set; }
    public int UserId { get; set; }
    public virtual ICollection<PlatformGateway> Platforms { get; set; }
}