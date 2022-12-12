using System;
using System.Collections.Generic;

namespace BasicEcommerce_BackEnd.Models;

public partial class OrderDetail
{
    public long IdOrderDetail { get; set; }

    public long IdOrder { get; set; }

    public long IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
