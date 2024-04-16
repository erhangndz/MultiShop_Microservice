using System.Security.Claims;

namespace Multishop.Basket.LoginServices
{
    public class LoginService(IHttpContextAccessor httpContextAccessor) : ILoginService
    {
        public string GetUserId => httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
