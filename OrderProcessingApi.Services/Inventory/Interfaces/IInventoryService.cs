using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Integrations;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryService
{
    void AddInventoryItems(List<Product> inventoryItems, Integration profile);
    public IEnumerable<Product> CreateProdeucts(IEnumerable<ProductDto> productDtos);

}