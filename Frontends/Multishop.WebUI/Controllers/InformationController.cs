using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class InformationController(IStringLocalizer<InformationController> _localizer) : Controller
    {
     

        [HttpPost]
        public IActionResult Index(string culture,string returnUrl)
        {
            

            return LocalRedirect(returnUrl);
        }
    }
}
