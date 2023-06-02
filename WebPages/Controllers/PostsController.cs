using Microsoft.AspNetCore.Mvc;
using MyWordBlog.DAL.Entidades;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebPages.Controllers
{
    public class PostsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public PostsController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Get(Guid? id)
        {
            var url = String.Format("https://localhost:7133/api/Commentary/Get/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            Post post = JsonConvert.DeserializeObject<Post>(json);
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var url = String.Format("{0}/{1}", _configuration["Api:CategoriesDeleteUrl"], id);
                await _httpClient.CreateClient().DeleteAsync(url);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
