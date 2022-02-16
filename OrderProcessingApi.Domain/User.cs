
namespace OrderProcessingApi.Domain;

public class User
{
    public int Id { get; set; }
    public string Auth0Id { get; set; }
    public DateTime DateLastModified { get; set; }
    public DateTime DateCreated { get; set; }
    public List<Product> Products { get; set; }
}