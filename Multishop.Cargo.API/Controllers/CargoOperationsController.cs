using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DTO.CargoOperationDtos;
using Multishop.Cargo.DTO.CustomerDtos;
using Multishop.Cargo.Entity.Entities;

namespace Multishop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController(IGenericService<CargoOperation> cargoOperationService,IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            cargoOperationService.TDelete(id);
            return Ok("Kargo Hareketleri silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCargoOperationDto createCargoOperationDto)
        {
            cargoOperationService.TCreate(mapper.Map<CargoOperation>(createCargoOperationDto));
            return Created();
        }

        [HttpPut]
        public IActionResult Update(UpdateCargoOperationDto updateCargoOperationDto)
        {
            cargoOperationService.TUpdate(mapper.Map<CargoOperation>(updateCargoOperationDto));
            return Ok("Kargo Hareketleri Güncellendi");
        }
    }
}
