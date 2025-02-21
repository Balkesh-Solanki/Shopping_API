using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }
}
