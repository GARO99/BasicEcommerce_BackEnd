using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class UserRequest
    {
#nullable disable
        [JsonRequired]
        public string Email { get; set; }
        [JsonRequired]
        public string Password { get; set; }
    }
}
