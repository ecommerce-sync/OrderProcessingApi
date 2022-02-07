using AutoMapper;
using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Mappers;

public class WooItemProfile : Profile
{
    public WooItemProfile()
    {
        CreateMap<InventoryItem, WooInventoryItem>()
            .ForPath(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Gsku))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<WooInventoryItem, InventoryItem>()
            .ForPath(dest => dest.Quantity, opt => opt.MapFrom(src => src.StockQuantity))
            .ForMember(dest => dest.Gsku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    }
}