using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public interface IInventoryInitialiser
{
    public bool Initialize(IntegrationDto integration, int userId);

}