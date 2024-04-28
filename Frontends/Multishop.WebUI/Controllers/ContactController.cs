using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;

namespace Multishop.WebUI.Controllers
{
    public class ContactController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            var client = new HttpClient();
            client.BaseAddress= new Uri("https://localhost:7060/api/");
            createContactDto.SendDate= DateTime.Now;
            createContactDto.IsRead = false;
            await client.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction("Index");
        }
    }
}
