using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWordBlog.DAL;
using MyWordBlog.DAL.Entidades;
using System.Drawing;
using DbUpdateException = Microsoft.EntityFrameworkCore.DbUpdateException;

namespace MyWordBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaryController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CommentaryController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(Commentary comment, Guid postId, String description)
        {
            try
            {
                // Agregar el comentario a la base de datos
                comment.Id = Guid.NewGuid();
                comment.Post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
                comment.Description = description;
                comment.ModifiedDate = null;
                comment.PublicationDate = DateTime.Now;
                _context.Commentaries.Add(comment);
                await _context.SaveChangesAsync();

                return Ok("Comentario realizado correctamente"); 
              
            }
            catch (DbUpdateException)
            {
                // Manejar cualquier error de base de datos
                return StatusCode(500, "Error al guardar el comentario en la base de datos");
            }
        }
    }
}
    