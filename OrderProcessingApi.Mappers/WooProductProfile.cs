using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Enums;

namespace OrderProcessingApi.Mappers;

public class WooProductProfile : Profile
{
    public WooProductProfile()
    {
        CreateMap<WooProduct, Product>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            ;
    }

    private static List<Platform> MapInventoryItemIntegrations(double price, string sku, int wooId)
    {
        var inventoryItemIntegrations = new List<Platform>
        {
            new()
            {
                PlatformType = PlatformEnum.Woo,
                PlatformPrice = price,
                PlatformSku = sku,
                PlatformId = wooId,
            }
        };

        return inventoryItemIntegrations;
    }
}