using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Comment.Context;
using Multishop.Comment.Entities;

namespace Multishop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(CommentContext context) : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetList()
        {
            var values = context.UserComments.ToList();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var values=  context.UserComments.Find(id);
            context.UserComments.Remove(values);
            context.SaveChanges();
            return Ok("Yorum Silindi");
        }

        [HttpPost]
        public IActionResult Create(UserComment userComment)
        {
            context.Add(userComment);
            context.SaveChanges();
            return Ok(userComment);
        }

        [HttpPut]
        public IActionResult Update(UserComment userComment)
        {
            context.Update(userComment);
            context.SaveChanges();
            return Ok("Yorum Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = context.UserComments.Find(id);
            return Ok(values);
        }

        [HttpGet("GetByProductId/{id}")]
        public IActionResult GetByProductId(string id)
        {
            var values = context.UserComments.Where(x=>x.ProductId== id).ToList();
            return Ok(values);
        }
    }
}
