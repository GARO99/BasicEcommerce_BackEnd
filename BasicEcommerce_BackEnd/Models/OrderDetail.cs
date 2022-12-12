using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Models;

public partial class OrderDetail
{
    public long IdOrderDetail { get; set; }

    public long IdOrder { get; set; }

    public long IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Amount { get; set; }

    [JsonIgnore]
    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
