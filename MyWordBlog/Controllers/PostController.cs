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

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public IActionResult GetPost(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<IActionResult> UpdatePost(Guid id, Post updatedPost)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Description = updatedPost.Description;
            post.Author = updatedPost.Author;
            post.ModifiedDate = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Post actualizado correctamente");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al actualizar el post en la base de datos");
            }
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
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            try
            {
                await _context.SaveChangesAsync();
                return Ok("Post eliminado correctamente");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al eliminar el post de la base de datos");
            }


        }



    }
}

