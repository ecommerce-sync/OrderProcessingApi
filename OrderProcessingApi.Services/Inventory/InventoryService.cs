using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Helpers;
using OrderProcessingApi.Helpers.Exceptions;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public InventoryService(IServiceProvider serviceProvider, IRepository repository, IMapper mapper)
    {
        _inventoryFetchers = new List<IInventoryServiceBase>
        {
            serviceProvider.GetService<IWooInventoryFetcher>()!
        };

        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<ProductResultDto> Get(int userId = 0)
    {
        var products = _repository.GetAll<ProductGateway>()
            .Where(p => p.UserId.ForceStringFromInt().Contains(userId.ForceStringFromInt()));

        var products2 = _repository.GetAll<ProductGateway>();
        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> productDtos, int userId)
    {
        var user = _repository.GetAll<UserGateway>().FirstOrDefault(u => u.Id == userId);

        if (user == null) throw new InvalidUserException();

        // ReSharper disable once PossibleMultipleEnumeration
        var productGateways = productDtos.Select(productDto => new ProductGateway
            {
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Description = productDto.Description,
                Quantity = productDto.Quantity,
                Title = productDto.Title,
                Gsku = productDto.Sku,
                ImageUrl = "",
                UserId = userId
            })
            .ToList();

        _repository.AddRange(productGateways);
        _repository.Commit();

        // ReSharper disable once PossibleMultipleEnumeration
        return productDtos;
    }

    
}