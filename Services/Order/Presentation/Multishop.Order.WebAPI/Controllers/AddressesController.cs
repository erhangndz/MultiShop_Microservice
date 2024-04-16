using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Order.Application.Features.Mediator.Commands.AddressCommands;
using Multishop.Order.Application.Features.Mediator.Queries.AddressQueries;

namespace Multishop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await mediator.Send(new GetAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await mediator.Send(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new RemoveAddressCommand(id));
            return Ok("Adres Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Adres Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            await mediator.Send(command);
            return Ok("Adres Güncellendi");
        }
    }
}
