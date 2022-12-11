using System;
using System.Collections.Generic;

namespace BasicEcommerce_BackEnd.Models;

public partial class Product
{
    public long IdProduct { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
