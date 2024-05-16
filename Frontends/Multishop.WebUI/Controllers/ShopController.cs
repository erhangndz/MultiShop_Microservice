using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Multishop.WebDTO.DTOs.CommentDtos;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        public IActionResult Index(string? id)
        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult ProductDetails(string id)
        {
            ViewBag.detail = id;
            return View();
        }

        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CommentDate = DateTime.Now;
            createCommentDto.Status = false;
            var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7016/api/comments", createCommentDto);
            return RedirectToAction("Index");
        }
    }
}
