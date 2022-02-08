﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OrderProcessingApi.Domain.Database;

public class UserGateway
{
    public int Id { get; set; }
    [Column("Auth0_Id")]
    public string Auth0Id { get; set; }
    [Column("Date_Last_Modified")]
    public DateTime DateLastModified { get; set; }
    [Column("Date_Created")]
    public DateTime DateCreated { get; set; }
    public virtual ICollection<ProductGateway> Products { get; set; }
}