using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class User
{
    public int Id { get; set; }
    [Column("Auth0_Id")]
    public string Auth0Id { get; set; }
    [Column("Last_Modified")]
    public DateTime LastModified { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}