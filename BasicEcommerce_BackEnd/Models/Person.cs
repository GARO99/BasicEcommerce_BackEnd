using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Models;

public partial class Person
{
    public string IdNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    [JsonIgnore]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
