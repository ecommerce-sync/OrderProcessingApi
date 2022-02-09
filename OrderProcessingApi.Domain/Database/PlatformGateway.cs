using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class PlatformGateway : GatewayBase
{
    [Column("Platform_Type")]
    public int PlatformType { get; set; }
    [Column("Platform_Sku")]
    public string PlatformSku { get; set; }
    [Column("Platform_Id")]
    public int PlatformId { get; set; }
    public double Price { get; set; }

    //Navigation Properties


}