using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class BundleGateway
{
    public BundleGateway()
    {
        this.Products = new HashSet<ProductGateway>();
    }
    public int Id { get; set; }
    public string BundleName { get; set; }
    public int Quantity { get; set; }
    [Column("Date_Last_Modified")]
    public DateTime DateLastModified { get; set; }
    [Column("Date_Created")]
    public DateTime DateCreated { get; set; }
    public virtual ICollection<ProductGateway> Products { get; set; }
}