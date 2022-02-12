using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Mappers;

public class ProductGatewayProfile : Profile
{
    public ProductGatewayProfile()
    {
        CreateMap<ProductGateway, ProductResultDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.PlatformType, opt => opt.MapFrom(src => "not configured yet"));
    }
}