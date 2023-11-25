using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
    }

}
