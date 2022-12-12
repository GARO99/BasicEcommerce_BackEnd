using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class ClientRequest
    {
        [JsonRequired]
        public string IdNumber { get; set; } = null!;
        [JsonRequired]
        public string FirstName { get; set; } = null!;
        [JsonRequired]
        public string LastName { get; set; } = null!;
        [JsonRequired]
        public string PhoneNumbre { get; set; } = null!;
    }
}
