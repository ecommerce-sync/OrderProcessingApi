using OrderProcessingApi.Domain.Enums;

namespace OrderProcessingApi.Domain;

public class Platform
{
    public int PlatformId { get; set; }
    public PlatformEnum PlatformType { get; set; }
    public string PlatformSku { get; set; }
    public double PlatformPrice { get; set; }
}