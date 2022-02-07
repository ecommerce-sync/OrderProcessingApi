using Newtonsoft.Json;

namespace OrderProcessingApi.Domain;

public class WooInventoryItem
{
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Title { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    public string Sku { get; set; }
    [JsonProperty("stock_quantity")]
    public string StockQuantity { get; set; }

}