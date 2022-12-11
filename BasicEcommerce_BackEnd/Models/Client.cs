using System;
using System.Collections.Generic;

namespace BasicEcommerce_BackEnd.Models;

public partial class Client
{
    public long Idclient { get; set; }

    public string? IdNumberPerson { get; set; }

    public string? PhoneNumbre { get; set; }

    public virtual Person? IdNumberPersonNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
