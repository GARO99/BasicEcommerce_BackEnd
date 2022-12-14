namespace BasicEcommerce_BackEnd.Models;

public partial class Order
{
    public long IdOrder { get; set; }

    public long Idclient { get; set; }

    public DateTime Date { get; set; }
    public decimal TotalAmount { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
