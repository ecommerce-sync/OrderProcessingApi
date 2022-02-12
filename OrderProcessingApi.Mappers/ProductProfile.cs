﻿using AutoMapper;
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
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => "src.Quantity"));
    }

    private static List<PlatformGateway> MapPlatforms(IEnumerable<Platform> inventoryItemIntegrations)
    {
        return inventoryItemIntegrations.Select(integration => new PlatformGateway
        {
            PlatformId = integration.PlatformId, 
            PlatformSku = integration.PlatformSku,
            Price = integration.PlatformPrice, 
            DateLastModified = DateTime.Now,
            DateCreated = DateTime.Now,
            PlatformType = MapPlatformType(integration.PlatformType)
        }).ToList();
    }

    private static int MapPlatformType(PlatformEnum platformEnum)
    {
        return platformEnum switch
        {
            PlatformEnum.Woo => 0,
            _ => 99
        };
    }
}