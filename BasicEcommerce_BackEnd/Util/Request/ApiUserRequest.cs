using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class ApiUserRequest
    {
        [JsonRequired]
        public string UserName { get; set; } = null!;
        [JsonRequired]
        public string Password { get; set; } = null!;
    }
}
