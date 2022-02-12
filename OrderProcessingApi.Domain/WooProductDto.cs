using Newtonsoft.Json;

namespace OrderProcessingApi.Domain;

public class WooProductDto
{
    public int WooId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public string StockQuantity { get; set; }
    public double Price { get; set; }
}