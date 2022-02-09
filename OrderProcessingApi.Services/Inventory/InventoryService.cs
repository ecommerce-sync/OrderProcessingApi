using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.IntegrationProfiles;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;

    public InventoryService(IServiceProvider serviceProvider)
    {
        _inventoryFetchers = new List<IInventoryServiceBase>
        {
            serviceProvider.GetService<IWooInventoryFetcher>()!
        };
    }

    public void AddInventoryItems(List<InventoryItem> inventoryItems, IntegrationProfile profile)
    {
        if (_inventoryFetchers.Any())
            foreach (var inventoryFetcher in _inventoryFetchers)
                inventoryFetcher.AddInventoryItems(inventoryItems, profile);
    }
}