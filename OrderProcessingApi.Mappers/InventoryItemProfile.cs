using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Mappers;

public class InventoryItemProfile : Profile
{
    public InventoryItemProfile()
    {
        CreateMap<InventoryItem, Product>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Gsku, opt => opt.MapFrom(src => src.Gsku))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Bundles, opt => opt.Ignore())
            .ForMember(dest => dest.Platforms, opt => opt.MapFrom(src => MapPlatforms(src.InventoryItemIntegrations)));
    }

    private static List<Platform> MapPlatforms(IEnumerable<InventoryItemIntegration> inventoryItemIntegrations)
    {
        return inventoryItemIntegrations.Select(integration => new Platform
        {
            PlatformId = integration.IntegrationId, 
            PlatformSku = integration.IntegrationSku,
            Price = integration.IntegrationPrice, 
            LastModified = DateTime.Now
        }).ToList();
    }
}