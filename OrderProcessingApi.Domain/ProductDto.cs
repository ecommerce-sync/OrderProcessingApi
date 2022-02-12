namespace OrderProcessingApi.Domain;

public class ProductsCreationDto
{
    public int UserId { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
}
public class ProductDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }
    public string PlatformType { get; set; }
    public int PlatformId { get; set; }

}

public class ProductResultDto : ProductDto
{
    public int UserId { get; set; }
}