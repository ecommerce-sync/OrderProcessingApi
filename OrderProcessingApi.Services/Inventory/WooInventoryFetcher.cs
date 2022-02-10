using AutoMapper;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.Integrations;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory.Interfaces;
using Integration = OrderProcessingApi.Domain.Integrations.Integration;

namespace OrderProcessingApi.Services.Inventory;

public class WooInventoryFetcher : IWooInventoryFetcher
{
    private readonly IFetchWooApiService _fetchWooApiService;
    private readonly IMapper _mapper;

    public WooInventoryFetcher(IFetchWooApiService fetchWooApiService, IMapper mapper)
    {
        _fetchWooApiService = fetchWooApiService;
        _mapper = mapper;
    }

    public void AddInventoryItems(List<Product> inventoryItems, Integration integration)
    {
        var items = _mapper.Map<List<Product>>(GetAll(integration.WooIntegration));
        inventoryItems.AddRange(items);
    }

    private IEnumerable<WooProduct> GetAll(WooIntegration integration)
    {
        _fetchWooApiService.SetCredentials(integration);

        var items = new List<WooProduct>();

        var prevId = 0;
        var n = 1;
        while (true)
        {
            var endpoint = $"wp-json/wc/v3/products?per_page=100&page={n}";
            var url = $"{integration.Url}{endpoint}";
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