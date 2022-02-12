using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class IntegrationGateway : GatewayBase
{
    public UserGateway User { get; set; }
    public int UserId { get; set; }
    public string WooConsumerKey { get; set; }
    public string WooConsumerSecret { get; set; }
    public string WooUrl { get; set; }
    
}