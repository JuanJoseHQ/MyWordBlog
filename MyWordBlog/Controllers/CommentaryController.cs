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
        public async Task<IActionResult> CreateComment(Commentary comment, Guid postId, String description, String Author)
        { 
            try
            {
                // Agregar el comentario a la base de datos
                comment.Id = Guid.NewGuid();
                comment.Author = Author;
                comment.Post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
                comment.Description = description;
                comment.ModifiedDate = null;
                comment.PublicationDate = DateTime.Now;
                _context.Commentary.Add(comment);
                await _context.SaveChangesAsync();

                return Ok("Comentario realizado correctamente"); 
              
            }
            catch (DbUpdateException)
            {
                // Manejar cualquier error de base de datos
                return StatusCode(500, "Error al guardar el comentario en la base de datos");
            }
        }
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public IActionResult GetComment(Guid id)
        {
            var comment = _context.Posts.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound("Comentario no existe");
            }
            return Ok(comment);
        }


        [HttpDelete, ActionName("Delete")]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var comment = _context.Commentary.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound("No se ha encontrado el Comentario");
            }
            
            try
            {
                _context.Commentary.Remove(comment);
                await _context.SaveChangesAsync();
                return Ok("Comentario eliminado correctamente");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al eliminar el comentario de la base de datos");
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("UpdateComment")]
        public async Task<IActionResult> UpdateComment(Guid id, Commentary updatedcomment)
        {
            var comment = _context.Commentary.FirstOrDefault(c => c.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.Description = updatedcomment.Description;
            comment.ModifiedDate = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Comentario actualizado correctamente");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al actualizar el comentario en la base de datos");
            }
        }
    }
}
    