using System.Security.Claims;
using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Fresko_BE.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PageController : Controller
    {

        private readonly AppDbContext _database;
        public PageController(AppDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<ActionResult<List<PageModel>>> Index()
        {
            var pages = _database.Pages.ToList();
            return Ok(pages);
        }


        [HttpPost]
        public async Task<ActionResult<PageModel>> Create([FromBody] PageViewRequest pageView)
        {
        //    if (!ApprovedCheck())
        //    {
        //        return BadRequest();
        //    }
            try
            {
                Page page = PageService.AddPage(pageView);
                page.user = await _database.Users.FindAsync(pageView.UserId);

                await _database.Pages.AddAsync(page);
                await _database.SaveChangesAsync();

                return Ok(page);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPage(int? id)
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pageFromDatabase = await _database.Pages.FindAsync(id);

            if (pageFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(pageFromDatabase);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] PageModel model)
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            try
            {
                var newObj = ComponentsService.UpdateComponent(model);

                _database.Pages.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Page edited successfully.";
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePage(int? id)
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            var obj = await _database.Pages.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Pages.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "Page deleted successfully.";
            return Ok(obj);
        }

        [HttpGet]
        [Route("/{pageName}")]
        public async Task<IActionResult> GetWebPage(string pageName)
        {
            //pageName = HttpContext.Request.Query["name"];
            Page page = _database.Pages.Where(p => p.page_name == pageName).ToList().FirstOrDefault();

            if (page == null)
            {
                return BadRequest();
            }

            List<ArticleText> articles = _database.Articles.Where(a => a.page.id == page.id).ToList();
            List<ImagePicker> images = _database.Images.Where(a => a.page.id == page.id).ToList();
            List<FilePicker> files = _database.Files.Where(a => a.page.id == page.id).ToList();
            List<LinkPicker> links = _database.Links.Where(a => a.page.id == page.id).ToList();

            WebPageView webPageView = new WebPageView()
            {
                pageId = page.id,
                Articles = articles,
                Images = images,
                Links = links,
                Files = files
            };

            return Ok(webPageView);
        }
        private bool ApprovedCheck()
        {
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
