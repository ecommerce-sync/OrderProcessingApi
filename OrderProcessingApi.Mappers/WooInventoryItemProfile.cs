using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Enums;

namespace OrderProcessingApi.Mappers;

public class WooInventoryItemProfile : Profile
{
    public WooInventoryItemProfile()
    {
        CreateMap<WooInventoryItem, InventoryItem>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.InventoryItemIntegrations, opt =>opt.MapFrom(src => MapInventoryItemIntegrations(src.Price, src.Sku, src.WooId)))
            ;
    }

    private static List<InventoryItemIntegration> MapInventoryItemIntegrations(double price, string sku, int wooId)
    {
        var inventoryItemIntegrations = new List<InventoryItemIntegration>
        {
            new()
            {
                Integration = IntegrationEnum.Woo,
                IntegrationPrice = price,
                IntegrationSku = sku,
                IntegrationId = wooId,
            }
        };

        return inventoryItemIntegrations;
    }
}