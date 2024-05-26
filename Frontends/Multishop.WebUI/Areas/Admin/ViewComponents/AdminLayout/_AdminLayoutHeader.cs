using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Services.MessageServices;
using Multishop.WebUI.Services.StatisticsServices.CommentStatisticsServices;

namespace Multishop.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeader(IUserService _userService,IMessageService _messageService,ICommentStatisticsService _commentStatisticsService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.name = user.Name + " " + user.Surname;
            ViewBag.messageCount = await _messageService.GetMessageCountByReceiverIdAsync(user.Id);
            ViewBag.passiveCommentCount = await _commentStatisticsService.GetPassiveCommentCountAsync();
            return View();
        }
    }
}
