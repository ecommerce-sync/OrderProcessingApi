using AutoMapper;
using OrderProcessingApi.Domain;

namespace OrderProcessingApi.Mappers;

public class WooItemProfile : Profile
{
    public WooItemProfile()
    {
        CreateMap<InventoryItem, WooItem>()
            .ForPath(dest => dest.stock_quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WooId));

        CreateMap<WooItem, InventoryItem>()
            .ForPath(dest => dest.Quantity, opt => opt.MapFrom(src => src.stock_quantity))
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.WooId, opt => opt.MapFrom(src => src.Id));
    }
}