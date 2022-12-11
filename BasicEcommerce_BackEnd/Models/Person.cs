using System;
using System.Collections.Generic;

namespace BasicEcommerce_BackEnd.Models;

public partial class Person
{
    public string IdNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
