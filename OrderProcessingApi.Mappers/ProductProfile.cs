using AutoMapper;
using Microsoft.OpenApi.Extensions;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Domain.Enums;

namespace OrderProcessingApi.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductGateway>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<PlatformGateway, ProductGateway>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

        CreateMap<WooProduct, Product>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<WooProduct, ProductGateway>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.StockQuantity))
            .ForMember(dest => dest.Platforms,
                opt => opt.MapFrom(src => MapPlatforms(src.Description, src.Title, src.WooId, src.Sku, src.Price)))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.User, opt => opt.Ignore());

        CreateMap<ProductGateway, ProductResultDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.PlatformType, opt => opt.MapFrom(src => "not configured yet"));
    }

    private static IEnumerable<PlatformGateway> MapPlatforms(string description, string title, int platformId, string sku, double price)
    {
        var platformGateways = new List<PlatformGateway>()
        {
            new()
            {
                Description = description,
                Title = title,
                PlatformId = platformId,
                PlatformType = PlatformEnum.Woo.GetDisplayName(),
                PlatformSku = sku,
                Price = price
            }
        };

        return platformGateways;
    }
}