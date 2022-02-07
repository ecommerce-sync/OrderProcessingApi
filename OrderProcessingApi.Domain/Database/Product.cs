using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class Product
{
    public Product()
    {
        this.Bundles = new HashSet<Bundle>();
        this.Platforms = new HashSet<Platform>();
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
    public virtual ICollection<Bundle> Bundles { get; set; }
    public virtual ICollection<Platform> Platforms { get; set; }

}