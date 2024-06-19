using Microsoft.AspNetCore.Mvc;
using Multishop.RabbitMQApi.Services;
using RabbitMQ.Client;
using System.Text;

namespace Multishop.RabbitMQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QMessagesController(RabbitMQService _service) : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateMessage()
        {
            var channel = _service.CreateChannel();
            channel.QueueDeclare("Queue2", false, false, false, null);
            var messageContent = "Merhaba bugün hava çok sıcak";

            var byteMessage = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "Queue2", basicProperties: null, body: byteMessage);
            return Ok("Mesaj Kuyruğa Alınmıştır.");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {
            return Ok();
        }
    }
}
