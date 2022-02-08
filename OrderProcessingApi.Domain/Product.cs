namespace OrderProcessingApi.Domain;

public class Product
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Gsku { get; set; }
    public int Quantity { get; set; }
    public IEnumerable<Platform> InventoryItemIntegrations { get; set; }
}