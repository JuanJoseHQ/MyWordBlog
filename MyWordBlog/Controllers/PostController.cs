using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWordBlog.DAL;

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
        
    }
    
       
       
    }

