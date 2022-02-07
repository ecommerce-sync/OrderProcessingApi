using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class Platform
{
    public Platform()
    {
        this.Products = new HashSet<Product>();
    }
    public int Id { get; set; }
    [Column("Platform_Type")]
    public int PlatformType { get; set; }
    [Column("Platform_Sku")]
    public string PlatformSku { get; set; }
    [Column("Platform_Id")]
    public int PlatformId { get; set; }
    public double Price { get; set; }
    [Column("Date_Last_Modified")]
    public DateTime DateLastModified { get; set; }
    [Column("Date_Created")]
    public DateTime DateCreated { get; set; }
    public virtual ICollection<Product> Products { get; set; }

}