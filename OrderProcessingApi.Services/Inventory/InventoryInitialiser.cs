using AutoMapper;
using Newtonsoft.Json;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Services.Inventory.Interfaces;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class InventoryInitialiser : IInventoryInitialiser
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;
    private readonly IRepository _repository;
    private readonly IUserValidationService _userValidationService;
    private readonly IWooInventoryService _wooInventoryService;
    private IMapper _mapper;

    public InventoryInitialiser(IWooInventoryService wooInventoryService, IMapper mapper)
    {
        _wooInventoryService = wooInventoryService;
        _mapper = mapper;
    }

    public bool Initialize(IntegrationDto integrationDto, int userId)
    {
        //AddInventoryItemsDb Integration
        var integration = _mapper.Map<Integration>(integrationDto);

        try
        {
            if (integration.WooConsumerSecret != null &&
                integration.WooConsumerKey != null & integration.WooUrl != null)
            {
                _wooInventoryService.AddInventoryItemsDb(integration, userId);
            }

            return true;
        }
        catch (JsonSerializationException)
        {
            return false;
        }
    }
}

