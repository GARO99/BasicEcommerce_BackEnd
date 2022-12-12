namespace BasicEcommerce_BackEnd.Models;

public partial class ApiUser
{
    public long IdApiUser { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
