namespace OrderProcessingApi.Domain.Database
{
    public interface IProduct
    {
        int Id { get; set; }
        string Title { get; set; }
        string Gsku { get; set; }
        string Description { get; set; }
        int Quantity { get; set; }
        string ImageUrl { get; set; }
        DateTime LastModified { get; set; }
        ICollection<Bundle> Bundles { get; set; }
        ICollection<Platform> Platforms { get; set; }
    }
}