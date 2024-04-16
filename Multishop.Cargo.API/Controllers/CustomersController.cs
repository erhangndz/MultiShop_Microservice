using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DTO.CustomerDtos;
using Multishop.Cargo.Entity.Entities;

namespace Multishop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IGenericService<Customer> customerService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = customerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = customerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerService.TDelete(id);
            return Ok("Müşteri silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto createCustomerDto)
        {
            customerService.TCreate(mapper.Map<Customer>(createCustomerDto));
            return Created();
        }

        [HttpPut]
        public IActionResult Update(UpdateCustomerDto updateCustomerDto)
        {
            customerService.TUpdate(mapper.Map<Customer>(updateCustomerDto));
            return Ok("Müşteri Güncellendi");
        }
    }
}
