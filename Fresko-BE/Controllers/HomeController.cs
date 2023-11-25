using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "AAAAAA";
        }
    }
}
