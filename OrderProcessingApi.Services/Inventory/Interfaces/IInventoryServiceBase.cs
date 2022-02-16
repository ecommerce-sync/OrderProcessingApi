using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryServiceBase
{
     void AddInventoryItems(List<Product> inventoryItems, Integration profile);
     public void AddInventoryItemsDb(Integration integration, int userId);

}