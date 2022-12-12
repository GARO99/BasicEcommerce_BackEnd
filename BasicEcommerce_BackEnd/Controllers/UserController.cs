using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util;
using BasicEcommerce_BackEnd.Util.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicEcommerce_BackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IAuthService> LazyAuthService;
        private IAuthService AuthService => LazyAuthService.Value;

        public UserController(Lazy<IAuthService> lazyAuthService)
        {
            LazyAuthService = lazyAuthService;
        }

        [HttpPost]
        [Route("login")]
        [SwaggerOperation(Summary = "Login user", Description = "Login a user to use the app")]
        [SwaggerResponse(200, Description = "User info", Type = typeof(User))]
        public IActionResult Login([FromBody, SwaggerRequestBody("User Credentials", Required = true)] UserRequest userRequest)
        {
            try
            {
                return Ok(this.AuthService.LoginApp(userRequest));
            }
            catch (Exception ex)
            {
                return Helper.GetExectionResponse(ex);
            }
        }
    }
}
