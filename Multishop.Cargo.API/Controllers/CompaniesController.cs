using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Cargo.Business.Abstract;
using Multishop.Cargo.DTO.CompanyDtos;
using Multishop.Cargo.Entity.Entities;

namespace Multishop.Cargo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController(IGenericService<Company> companyService,IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var values = companyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = companyService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            companyService.TDelete(id);
            return Ok("Kargo Şirketi silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCompanyDto createCompanyDto)
        {
            companyService.TCreate(mapper.Map<Company>(createCompanyDto));
            return Created();
        }

        [HttpPut]
        public IActionResult Update(UpdateCompanyDto updateCompanyDto)
        {
            companyService.TUpdate(mapper.Map<Company>(updateCompanyDto));
            return Ok("Kargo Şirketi Güncellendi");
        }
    }
}
