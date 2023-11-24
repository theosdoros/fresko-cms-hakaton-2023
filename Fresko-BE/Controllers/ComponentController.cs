using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
