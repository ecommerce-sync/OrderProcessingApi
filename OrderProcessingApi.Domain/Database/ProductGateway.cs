using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class ProductGateway
{
    public ProductGateway()
    {
        this.Bundles = new HashSet<BundleGateway>();
        this.Platforms = new HashSet<PlatformGateway>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Gsku { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    [Column("Date_Last_Modified")]
    public DateTime DateLastModified { get; set; }
    [Column("Date_Created")]
    public DateTime DateCreated { get; set; }
    public virtual ICollection<BundleGateway> Bundles { get; set; }
    public virtual ICollection<PlatformGateway> Platforms { get; set; }

}