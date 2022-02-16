using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Database;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory.Interfaces;

namespace OrderProcessingApi.Services.Inventory;

public class WooInventoryService : IWooInventoryService
{
    private readonly IFetchWooApiService _fetchWooApiService;
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IConfigurationService _configurationService;
    public WooInventoryService(IFetchWooApiService fetchWooApiService, IMapper mapper, IRepository repository, IConfigurationService configurationService)
    {
        _fetchWooApiService = fetchWooApiService;
        _mapper = mapper;
        _repository = repository;
        _configurationService = configurationService;
    }

    public void AddInventoryItems(List<Product> inventoryItems, Integration integration)
    {
        var items = _mapper.Map<List<Product>>(GetAll(integration));
        inventoryItems.AddRange(items);
    }

    public void AddInventoryItemsDb(Integration integration, int userId)
    {
        var wooProducts = GetAll(integration);

        var products = _mapper.Map<IEnumerable<ProductGateway>>(wooProducts).Select(p =>
        {
            p.UserId = userId;
            return p;
        }).ToList(); ;

        _repository.AddRange(products);
        _repository.Commit();
    }

    private IEnumerable<WooProduct> GetAll(Integration integration)
    {
        _fetchWooApiService.SetCredentials(integration);

        var items = new List<WooProduct>();

        var prevId = 0;
        var n = 1;
        while (true)
        {
            var endpoint = $"{_configurationService.WooConfigurations.GetProductsEndpoint}?per_page=100&page={n}";
            var url = $"{integration.WooUrl}{endpoint}";
            var tempProducts = _fetchWooApiService.GetApiResponseJson<IEnumerable<WooProduct>>(url).ToList();

            var currentId = tempProducts.LastOrDefault()?.WooId ?? 0;
            if (currentId == prevId) break;

            prevId = currentId;
            n++;
            items.AddRange(tempProducts);
        }

        return items;
    }
}