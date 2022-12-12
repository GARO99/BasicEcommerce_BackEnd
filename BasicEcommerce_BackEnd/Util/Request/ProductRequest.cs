using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class ProductRequest
    {
        public long? IdProduct { get; set; }
        [JsonRequired]
        public string ProductName { get; set; } = null!;

        [JsonRequired]
        public decimal Price { get; set; }
    }
}
