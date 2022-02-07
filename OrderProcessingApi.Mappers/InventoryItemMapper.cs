using AccStatsApi.Services.Mappers.Base;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Mappers.Interfaces;

namespace OrderProcessingApi.Mappers;

public class InventoryItemMapper : IInventoryItemMapper
{
    protected override void MapAtoB(InventoryItem inventoryItem, TProduct product)
    {
        product.Title = inventoryItem.Title;
        product.Description = inventoryItem.Description;
        product.Gsku = inventoryItem.Gsku;
        product.Quantity = inventoryItem.Quantity;
        product.LastModified = DateTime.Now;
        product.Platforms = new List<Platform>();

        foreach (var integration in inventoryItem.InventoryItemIntegrations)
        {
            product.Platforms.Add(new Platform()
            {
                PlatformId = integration.IntegrationId,
                PlatformSku = integration.IntegrationSku,
                Price = integration.IntegrationPrice,
                LastModified = DateTime.Now
            });
        }
    }
}