using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWordBlog.DAL;
using MyWordBlog.DAL.Entidades;

namespace MyWordBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public PostController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost, ActionName("Create")]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(Post post, String title, String author, String description)
        {
            try
            {
                // Agregar post a la base de datos
                post.Title = title;
                post.Id = Guid.NewGuid();
                post.PublicationDate = DateTime.Now;
                post.ModifiedDate = null;
                post.CountDisLikes = null;
                post.CountLikes = null;
                post.Author = author;
                post.Description = description;
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return Ok("Post realizado correctamente");

            }
            catch (DbUpdateException)
            {
                // Manejar cualquier error de base de datos
                return StatusCode(500, "Error al realizar el post en la base de datos");
            }

        }



    }
}

