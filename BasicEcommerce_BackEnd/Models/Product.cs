using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Models;

public partial class Product
{
    public long IdProduct { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
