using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.Mediator.Commands.AddressCommands;
using Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using Multishop.Order.Application.Features.Mediator.Queries.AddressQueries;
using Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;

namespace Multishop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await mediator.Send(new GetOrderDetailQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş Detayları Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Detayları Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand command)
        {
            await mediator.Send(command);
            return Ok("Sipariş Detayları Güncellendi");
        }
    }
}
