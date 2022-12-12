using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class OrderDetailRequest
    {
        [JsonRequired]
        public long IdProduct { get; set; }
        [JsonRequired]
        public int Quantity { get; set; }
        [JsonRequired]
        public decimal Amount { get; set; }
    }
}
