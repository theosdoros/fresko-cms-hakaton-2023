using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Models.Interfaces;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    public class ComponentController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "RADI";
        }

        [HttpPost]
        public IActionResult AddArticle([FromBody] ArticleTextModel model)
        {
            try
            {
                ComponentsService.AddComponent(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IActionResult RemoveComponent(IComponent component)
        {
            try
            {
                ComponentsService.RemoveComponent(component);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
