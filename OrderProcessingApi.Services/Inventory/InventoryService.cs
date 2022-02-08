using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Domain.IntegrationProfiles;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public InventoryService(IServiceProvider serviceProvider, IRepository repository, IMapper mapper)
    {
        _inventoryFetchers = new List<IInventoryServiceBase>
        {
            serviceProvider.GetService<IWooInventoryFetcher>()!
        };

        _repository = repository;
        _mapper = mapper;
    }

    public void AddInventoryItems(List<Product> inventoryItems, Integration integration)
    {
        if (_inventoryFetchers.Any())
            foreach (var inventoryFetcher in _inventoryFetchers)
                inventoryFetcher.AddInventoryItems(inventoryItems, integration);

        var products = inventoryItems.Select(inventoryItem => _mapper.Map<ProductGateway>(inventoryItem)).ToList();
        
        _repository.AddRange(products);
        _repository.Commit();
    }
}