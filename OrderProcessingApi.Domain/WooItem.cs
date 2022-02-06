namespace OrderProcessingApi.Domain;

public struct WooItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
    public string stock_quantity { get; set; }
}