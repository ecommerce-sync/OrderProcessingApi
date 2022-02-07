using AutoMapper;
using OrderProcessingApi.Data.Interfaces;
using OrderProcessingApi.Domain;
using OrderProcessingApi.Domain.IntegrationProfiles;
using OrderProcessingApi.Services.ApiServices.Interfaces;
using OrderProcessingApi.Services.Inventory.Interfaces;

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

    public void AddInventoryItems(List<InventoryItem> inventoryItems, IntegrationProfile profile)
    {

        var items = _mapper.Map<List<InventoryItem>>(GetAll(profile.WooIntegrationProfile));
        inventoryItems.AddRange(items);
    }

    private IEnumerable<WooInventoryItem> GetAll(WooIntegrationProfile profile)
    {
        _fetchWooApiService.SetCredentials(profile);

        var items = new List<WooInventoryItem>();

        var prevId = "";
        var n = 1;
        while (true)
        {
            var endpoint = $"wp-json/wc/v3/products?per_page=100&page={n}";
            var url = $"{profile.Url}{endpoint}";
            var tempProducts = _fetchWooApiService.GetApiResponseJson<IEnumerable<WooInventoryItem>>(url).ToList();

            var currentId = tempProducts.LastOrDefault().Id ?? "";
            if (currentId == prevId) break;

            prevId = currentId;
            n++;
            items.AddRange(tempProducts);
        }

        return items;
    }
}