using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWordBlog.DAL;
using MyWordBlog.DAL.Entidades;
using DbUpdateException = Microsoft.EntityFrameworkCore.DbUpdateException;

namespace MyWordBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentaryController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ComentaryController(DataBaseContext context)
        {
            _context = context;
        }
    }
}