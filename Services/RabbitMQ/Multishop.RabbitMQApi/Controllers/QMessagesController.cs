using Microsoft.AspNetCore.Mvc;
using Multishop.RabbitMQApi.Services;
using RabbitMQ.Client;
using System.Text;

namespace Multishop.RabbitMQApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QMessagesController(IRabbitMQService _service) : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateMessage()
        {
            _service.QueueDeclare("Queue3");
            _service.BasicPublish("Queue3", "Bu bir deneme mesaj içeriğidir");
            return Ok("Mesaj Kuyruğa Alınmıştır.");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {
            return Ok();
        }
    }
}
