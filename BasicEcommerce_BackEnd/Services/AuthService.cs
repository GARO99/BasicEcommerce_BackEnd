using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Settings;
using BasicEcommerce_BackEnd.Util;
using BasicEcommerce_BackEnd.Util.Exceptions;
using BasicEcommerce_BackEnd.Util.Request;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BasicEcommerce_BackEnd.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings AppSettings;
        private readonly BasicEcommerceContext DbContext;

        public AuthService(IOptions<AppSettings> appSettings, BasicEcommerceContext dbContex)
        {
            AppSettings = appSettings.Value;
            DbContext = dbContex;
        }

        public string GetToken(ApiUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] tokenKey = Encoding.UTF8.GetBytes(AppSettings.Jwt.Key);
            SecurityTokenDescriptor TokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials =  new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            SecurityToken token = tokenHandler.CreateToken(TokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public ApiUser CheckApiUser(ApiUserRequest apiUserRequest)
        {
            ApiUser? user = this.DbContext.ApiUsers.FirstOrDefault(a => a.UserName == apiUserRequest.UserName && 
            a.Password == apiUserRequest.Password);
            if (user == null)
            {
                throw new UnauthorizedException("User not found");
            }

            return user;
        }

        public User LoginApp(UserRequest userRequest)
        {
            User? user = this.DbContext.Users.FirstOrDefault(u => u.Email == userRequest.Email &&
            u.Password == userRequest.Password);
            if (user == null)
            {
                throw new ForbiddenException("User app not found");
            }
            this.DbContext.Entry(user).Reference(u => u.Person).Load();

            return user;
        }
    }
}
