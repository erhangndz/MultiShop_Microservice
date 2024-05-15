using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CommentDtos;
using Multishop.WebUI.Services.CommentServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CommentController(ICommentService _commentService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _commentService.GetAllCommentsAsync();
            return View(values);
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateComment(int id)
        {
            var values = await _commentService.GetCommentByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            await _commentService.UpdateCommentAsync(updateCommentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCommentsByProductId(string id)
        {
            var values = await _commentService.GetCommentsByProductIdAsync(id);
            return View(values);
        }
    }
}
