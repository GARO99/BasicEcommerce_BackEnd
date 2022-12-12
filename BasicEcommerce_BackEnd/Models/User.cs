using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Models;

public partial class User
{
    public long IdUser { get; set; }

    public string IdNumberPerson { get; set; } = null!;

    public string Email { get; set; } = null!;
    [JsonIgnore]
    public string Password { get; set; } = null!;

    public virtual Person? Person { get; set; }
}
