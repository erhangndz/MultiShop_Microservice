using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace Multishop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetOrderingQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetOrderingByIdQuery(id)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Güncellendi");
        }

        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var values = await mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(values);
        }
    }
}
