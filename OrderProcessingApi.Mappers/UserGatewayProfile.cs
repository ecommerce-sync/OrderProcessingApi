using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Mappers;

public class UserGatewayProfile : Profile
{
    public UserGatewayProfile()
    {
        CreateMap<UserGateway, UserResultDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.Integrations, opt => opt.MapFrom(src => src.Integrations));

        CreateMap<UserResultDto, UserGateway>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));
    }
}