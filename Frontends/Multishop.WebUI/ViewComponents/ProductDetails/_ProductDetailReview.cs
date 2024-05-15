using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CommentDtos;
using Multishop.WebUI.Services.CommentServices;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{

    public class _ProductDetailReview(ICommentService _commentService):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.ProductId = id;
            var values = await _commentService.GetCommentsByProductIdAsync(id);
            return View(values);
        }
    }
}
