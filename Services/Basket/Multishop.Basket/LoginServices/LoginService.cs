using System.Security.Claims;

namespace Multishop.Basket.LoginServices
{
    public class LoginService(IHttpContextAccessor httpContextAccessor) : ILoginService
    {
        public string GetUserId()
        {
           return httpContextAccessor.HttpContext.User.FindFirstValue("sub");
        }
    }
}
