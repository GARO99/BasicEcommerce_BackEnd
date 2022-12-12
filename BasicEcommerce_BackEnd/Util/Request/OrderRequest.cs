using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class OrderRequest
    {
        public long IdOrder { get; set; }
        [JsonRequired]
        public long Idclient { get; set; }
        [JsonRequired]
        public DateTime Date { get; set; }
        [JsonRequired]
        public decimal TotalAmount { get; set; }
        [JsonRequired]
        public ICollection<OrderDetailRequest> OrderDetails { get; set; } = new List<OrderDetailRequest>();
    }
}
