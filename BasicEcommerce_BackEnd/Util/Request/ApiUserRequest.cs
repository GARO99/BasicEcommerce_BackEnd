using System.Text.Json.Serialization;

namespace BasicEcommerce_BackEnd.Util.Request
{
    public class ApiUserRequest
    {
#nullable disable
        [JsonRequired]
        public string UserName { get; set; }
        [JsonRequired]
        public string Password { get; set; }
    }
}
