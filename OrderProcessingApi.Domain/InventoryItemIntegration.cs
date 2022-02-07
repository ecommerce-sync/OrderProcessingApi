using OrderProcessingApi.Domain.Enums;

namespace OrderProcessingApi.Domain;

public class InventoryItemIntegration
{
    public string IntegrationId { get; set; }
    public IntegrationEnum Integration { get; set; }
    public string IntegrationSku { get; set; }
    public double IntegrationPrice { get; set; }
}