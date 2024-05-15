using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;
using Multishop.WebUI.Services.CatalogServices.ContactServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController(IContactService _contactService) : Controller
    {
        

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllContactsAsync();
            return View(values);
        }

       

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("Index");
        }

        
    }
}
