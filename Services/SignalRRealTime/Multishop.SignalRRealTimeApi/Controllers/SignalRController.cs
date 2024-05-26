using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.SignalRRealTimeApi.Services;

namespace Multishop.SignalRRealTimeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignalRController(ISignalRService _signalRService) : ControllerBase
    {

        [HttpGet("GetMessageCountByReceiverIdAsync/{id}")]
        public async Task<IActionResult> GetMessageCountByReceiverIdAsync(string id)
        {
            var values = await _signalRService.GetMessageCountByReceiverIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetPassiveCommentCountAsync")]
        public async Task<IActionResult> GetPassiveCommentCountAsync()
        {
            var values = await _signalRService.GetPassiveCommentCountAsync();
            return Ok(values);
        }
    }
}
