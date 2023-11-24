using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
