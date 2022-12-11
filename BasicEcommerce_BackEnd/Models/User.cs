using System;
using System.Collections.Generic;

namespace BasicEcommerce_BackEnd.Models;

public partial class User
{
    public long IdUser { get; set; }

    public string? IdNumberPerson { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual Person? IdNumberPersonNavigation { get; set; }
}
