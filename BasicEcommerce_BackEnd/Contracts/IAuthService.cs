using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Contracts
{
    public interface IAuthService
    {
        string GetToken(ApiUser user);

        bool CheckToken();

        bool LoginApp();

        ApiUser CheckApiUser(ApiUserRequest apiUserRequest);
    }
}
