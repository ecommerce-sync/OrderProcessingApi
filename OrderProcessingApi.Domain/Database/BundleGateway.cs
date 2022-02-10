using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

[Table("Bundles")]
public class BundleGateway : GatewayBase
{
    public string BundleName { get; set; }
    public int Quantity { get; set; }

    //Navigation Properties
}