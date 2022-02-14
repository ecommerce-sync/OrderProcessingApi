using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Helpers;
using OrderProcessingApi.Services.Inventory.Interfaces;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IUserValidationService _userValidationService;

    public InventoryService(IServiceProvider serviceProvider, IRepository repository, IMapper mapper, IUserValidationService userValidationService)
    {
        _inventoryFetchers = new List<IInventoryServiceBase>
        {
            serviceProvider.GetService<IWooInventoryService>()!
        };

        _repository = repository;
        _mapper = mapper;
        _userValidationService = userValidationService;
    }

    public IEnumerable<ProductResultDto> Get(int userId)
    {
        var products = _repository.GetAll<ProductGateway>()
            .Where(p => p.Id.ForceStringFromInt().Contains(userId.ForceStringFromInt()));

        var products2 = _repository.GetAll<ProductGateway>();
        return _mapper.Map<IEnumerable<ProductResultDto>>(products);
    }

    public IEnumerable<ProductDto> CreateProducts(IEnumerable<ProductDto> productDtos, int userId)
    {
        _userValidationService.ValidateUser(userId);

        // ReSharper disable once PossibleMultipleEnumeration
        var productGateways = productDtos.Select(productDto => new ProductGateway
            {
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now,
                Description = productDto.Description,
                Quantity = productDto.Quantity,
                Title = productDto.Title,
                Id = userId
            })
            .ToList();

        _repository.AddRange(productGateways);
        _repository.Commit();

        // ReSharper disable once PossibleMultipleEnumeration
        return productDtos;
    }

    
}