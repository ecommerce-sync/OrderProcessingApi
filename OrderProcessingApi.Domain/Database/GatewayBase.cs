using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class GatewayBase
{
    public int Id { get; set; }

    [Column("Date_Last_Modified")]
    public DateTime DateLastModified { get; set; }
    [Column("Date_Created")]
    public DateTime DateCreated { get; set; }
}