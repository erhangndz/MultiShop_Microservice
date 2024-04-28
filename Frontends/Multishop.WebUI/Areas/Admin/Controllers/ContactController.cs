using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ContactDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }

       

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _client.DeleteAsync("contacts/" + id);
            return RedirectToAction("Index");
        }

        
    }
}
