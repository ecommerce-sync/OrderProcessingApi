using Newtonsoft.Json;

namespace OrderProcessingApi.Domain;

public class WooInventoryItem
{
    [JsonProperty("id")]
    public int WooId { get; set; }
    [JsonProperty("name")]
    public string Title { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    public string Sku { get; set; }
    [JsonProperty("stock_quantity")]
    public string StockQuantity { get; set; }
    [JsonProperty("price")]
    public double Price { get; set; }
    

}