using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class Bundle
{
    public Bundle()
    {
        this.Products = new HashSet<Product>();
    }
    public int Id { get; set; }
    public string BundleName { get; set; }
    public int Quantity { get; set; }
    [Column("Last_Modified")]
    public DateTime LastModified { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}