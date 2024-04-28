using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ContactDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.ContactServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService,IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _contactService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultContactDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            var newValue = _mapper.Map<Contact>(createContactDto);
            await _contactService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _contactService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _contactService.UpdateAsync(value);
            return Ok("Mesaj Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactService.DeleteAsync(id);
            return Ok("Mesaj Silindi");
        }

    }
}
