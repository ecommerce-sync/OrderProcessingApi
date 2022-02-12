using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Mappers;

public class IntegrationProfile : Profile
{
    public IntegrationProfile()
    {
        CreateMap<IntegrationDto, IntegrationGateway>()
            .ForMember(dest => dest.WooConsumerKey, opt => opt.MapFrom(src => src.WooConsumerKey))
            .ForMember(dest => dest.WooConsumerSecret, opt => opt.MapFrom(src => src.WooConsumerSecret))
            .ForMember(dest => dest.WooUrl, opt => opt.MapFrom(src => src.WooUrl))
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<IntegrationGateway, IntegrationDto>()
            .ForMember(dest => dest.WooConsumerKey, opt => opt.MapFrom(src => src.WooConsumerKey))
            .ForMember(dest => dest.WooConsumerSecret, opt => opt.MapFrom(src => src.WooConsumerSecret))
            .ForMember(dest => dest.WooUrl, opt => opt.MapFrom(src => src.WooUrl));
    }
}