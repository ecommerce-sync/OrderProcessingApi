using OrderProcessingApi.Domain;

public interface IInventoryInitialiser
{
    public void Initialize(IntegrationDto integration, int userId);

}
