using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.IntegrationProfiles;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryService
{
    void AddInventoryItems(List<InventoryItem> inventoryItems, IntegrationProfile profile);
}