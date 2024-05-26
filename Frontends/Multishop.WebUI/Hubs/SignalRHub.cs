using Microsoft.AspNetCore.SignalR;
using Multishop.SignalRRealTimeApi.Services;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Hubs
{
    public class SignalRHub(ISignalRService _signalRService,IUserService userService):Hub
    {

        public async Task SendStatisticsCount()
        {
            var passiveCommentCount = await _signalRService.GetPassiveCommentCountAsync();
            await Clients.All.SendAsync("ReceiveCommentCount", passiveCommentCount.ToString());
            var user = await userService.GetUserInfo();
            var messageCount = await _signalRService.GetMessageCountByReceiverIdAsync(user.Id);
            await Clients.All.SendAsync("ReceiveMessageCount", messageCount.ToString());
        }

    }
}
