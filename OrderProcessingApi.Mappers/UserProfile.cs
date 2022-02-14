using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;

namespace OrderProcessingApi.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserGateway>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.DateLastModified, opt => opt.MapFrom(src => src.DateLastModified))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => new List<ProductGateway>()));

        CreateMap<UserGateway, UserResultDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.Integration, opt => opt.MapFrom(src => src.Integration));

        CreateMap<UserResultDto, UserGateway>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated));
    }
}