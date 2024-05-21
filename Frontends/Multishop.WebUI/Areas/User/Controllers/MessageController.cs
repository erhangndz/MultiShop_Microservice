using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Services.MessageServices;

namespace Multishop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController(IMessageService _messageService,IUserService _userService) : Controller
    {
        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessagesAsync(user.Id);
            return View(values);
        }


        public async Task<IActionResult> SentBox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSentBoxMessagesAsync(user.Id);
            return View(values);
        }
    }
}
