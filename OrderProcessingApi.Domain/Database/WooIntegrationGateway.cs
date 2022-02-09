using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

[Table("Woo_Integrations")]
public class WooIntegrationGateway : GatewayBase
{
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string Url { get; set; }
}