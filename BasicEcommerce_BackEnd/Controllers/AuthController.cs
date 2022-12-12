using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Util;
using BasicEcommerce_BackEnd.Util.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicEcommerce_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Lazy<IAuthService> LazyAuthService;
        private IAuthService AuthService => LazyAuthService.Value;

        public AuthController(Lazy<IAuthService> lazyAuthService)
        {
            LazyAuthService = lazyAuthService;
        }

        [HttpPost]
        [Route("token")]
        [SwaggerOperation(Summary = " Gets token", Description = "Gets token to uses in our API")]
        [SwaggerResponse(200, Description = "Api token", Type = typeof(string))]
        public IActionResult GetToken([FromBody, SwaggerRequestBody("User Credentials", Required = true)] ApiUserRequest apiUser)
        {
            try
            {
                return Ok(this.AuthService.GetToken(this.AuthService.CheckApiUser(apiUser)));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
