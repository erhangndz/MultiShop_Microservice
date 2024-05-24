using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Message.Dtos;
using Multishop.Message.Services;

namespace Multishop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IUserMessageService _userMessageService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok(createMessageDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Güncellendi");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var values = await _userMessageService.GetMessageByIdAsync(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj Silindi");
        }

        [HttpGet("GetInbox/{id}")]

        public async Task<IActionResult> GetInbox(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetSentBox/{id}")]

        public async Task<IActionResult> GetSentbox(string id)
        {
            var values = await _userMessageService.GetSentBoxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageCount")]

        public async Task<IActionResult> GetMessageCount()
        {
            var values = await _userMessageService.GetTotalMessageCountAsync();
            return Ok(values);
        }


    }
}
