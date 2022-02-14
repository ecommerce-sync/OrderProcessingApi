using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.Users.Interfaces;

namespace OrderProcessingApi.Services.Inventory.Interfaces;

public class InventoryInitialiser : IInventoryInitialiser
{
    private readonly IEnumerable<IInventoryServiceBase> _inventoryFetchers;
    private readonly IRepository _repository;
    private readonly IUserValidationService _userValidationService;
    private readonly IWooInventoryService _wooInventoryService;

    public InventoryInitialiser(IWooInventoryService wooInventoryService)
    {
        _wooInventoryService = wooInventoryService;
    }

    //public InventoryInitialiser(IServiceProvider serviceProvider, IUserValidationService userValidationService)
    //{
    //    _inventoryFetchers = new List<IInventoryServiceBase>
    //    {
    //        serviceProvider.GetService<IWooInventoryService>()!
    //    };
    //}

    public void Initialize(IntegrationDto integrationDto, int userId)
    {
        //Initialize Integration
        var integration = new Integration()
        {
            WooConsumerSecret = integrationDto.WooConsumerSecret,
            WooConsumerKey = integrationDto.WooConsumerKey,
            WooUrl = integrationDto.WooUrl
        };

        if (integration.WooConsumerSecret != null && integration.WooConsumerKey != null & integration.WooUrl != null)
        {
            _wooInventoryService.Initialize(integration, userId);
        }

    }
}

