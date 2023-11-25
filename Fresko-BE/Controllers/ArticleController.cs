using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArticleController : Controller
    {
        [HttpGet]
        public List<ArticleTextModel> Index()
        {
            return ArticleService.GetAllArticles();
        }

        [HttpGet]
        public ArticleTextModel GetArticle([FromBody] int id)
        {
            return ArticleService.GetArticle(id);
        }

        [HttpPost]
        public ArticleTextModel AddArticle([FromBody] ArticleTextModel article)
        {
            return ArticleService.AddArticle(article);
        }
        [HttpPost]
        public IActionResult DeleteArticle([FromBody] int id)
        {
            ArticleService.DeleteArticle(id);
            return Ok();
        }
    }
}
