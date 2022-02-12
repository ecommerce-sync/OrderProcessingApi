using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Domain.Enums;
using OrderProcessingApi.Domain.Integrations;
using Integration = OrderProcessingApi.Domain.Integrations.Integration;

namespace OrderProcessingApi.Mappers;

public class UserDtoProfile : Profile
{
    public UserDtoProfile()
    {
        CreateMap<UserDto, UserGateway>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Auth0Id, opt => opt.MapFrom(src => src.Auth0Id))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
            .ForMember(dest => dest.DateLastModified, opt => opt.MapFrom(src => src.DateLastModified))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => new List<ProductGateway>()));
    }
}