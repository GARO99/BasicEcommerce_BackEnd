using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class UserRequest
    {
        [JsonRequired]
        public string Email { get; set; } = null!;
        [JsonRequired]
        public string Password { get; set; } = null!;
    }
}
