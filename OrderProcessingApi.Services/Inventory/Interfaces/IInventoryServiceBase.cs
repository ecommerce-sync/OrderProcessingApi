using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.IntegrationProfiles;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryServiceBase
{
     void AddInventoryItems(List<Product> inventoryItems, IntegrationProfile profile);
}