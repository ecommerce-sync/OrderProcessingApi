namespace OrderProcessingApi.Domain;

public struct InventoryItem
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public string Quantity { get; set; }
    public string WooId { get; set; }
}