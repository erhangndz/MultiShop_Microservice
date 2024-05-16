using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;
using Multishop.WebUI.Services.CatalogServices.ContactServices;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController(IContactService _contactService) : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index");
        }
    }
}
