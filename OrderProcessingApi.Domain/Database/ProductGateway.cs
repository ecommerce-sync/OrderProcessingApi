namespace OrderProcessingApi.Domain.Database;

public class ProductGateway : GatewayBase
{
    public string Title { get; set; }
    public string Gsku { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public UserGateway User { get; set; }
    public int UserId { get; set; }
}