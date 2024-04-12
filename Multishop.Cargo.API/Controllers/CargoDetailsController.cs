using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DTO.CargoDetailDtos;
using Multishop.Cargo.DTO.CustomerDtos;
using Multishop.Cargo.Entity.Entities;

namespace Multishop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController(IGenericService<CargoDetail> cargoDetailService,IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            cargoDetailService.TDelete(id);
            return Ok("Kargo Detayları silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCargoDetailDto createCargoDetailDto)
        {
            cargoDetailService.TCreate(mapper.Map<CargoDetail>(createCargoDetailDto));
            return Created();
        }

        [HttpPut]
        public IActionResult Update(UpdateCargoDetailDto updateCargoDetailDto)
        {
            cargoDetailService.TUpdate(mapper.Map<CargoDetail>(updateCargoDetailDto));
            return Ok("Kargo Detayları Güncellendi");
        }
    }
}
