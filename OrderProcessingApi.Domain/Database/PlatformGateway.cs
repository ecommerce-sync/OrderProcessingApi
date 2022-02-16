using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class PlatformGateway : GatewayBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PlatformType { get; set; }
    public string PlatformSku { get; set; }
    public int PlatformId { get; set; }
    public double Price { get; set; }
    public virtual ProductGateway Product { get; set; }
    public int ProductId { get; set; }

}