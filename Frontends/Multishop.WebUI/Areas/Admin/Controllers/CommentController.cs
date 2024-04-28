using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CommentDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly HttpClient _client;

        public CommentController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7016/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCommentDto>>("comments");
            return View(values);
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            await _client.PostAsJsonAsync("comments", createCommentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteComment(string id)
        {
            await _client.DeleteAsync("comments/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateComment(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            await _client.PutAsJsonAsync("comments", updateCommentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCommentsByProductId(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCommentDto>>("comments/getByProductId/" + id);
            return View(values);
        }
    }
}
