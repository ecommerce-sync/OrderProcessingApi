using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryService
{
    public IEnumerable<ProductResultDto> Get(int userId = 0);
    public IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> productDtos, int userId);

}