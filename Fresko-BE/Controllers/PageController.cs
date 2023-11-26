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

        [HttpGet]
        [Route("/page/{pageId}")]
        public async Task<ActionResult<WebPageView>> GetPageById(int pageId)
        {
            //if (!ApprovedCheck())
            //{
            //    return BadRequest();
            //}
            if (pageId == null || pageId == 0)
            {
                return NotFound();
            }

            Page pageFromDatabase = await _database.Pages.FindAsync(pageId);

            if (pageFromDatabase == null)
            {
                return NotFound();
            }

            WebPageView webPageView = new WebPageView()
            {
                pageId = pageId,
                Articles = _database.Articles.Where(a => a.page.id == pageId).ToList(),
                Images = _database.Images.Where(a => a.page.id == pageId).ToList(),
                Files = _database.Files.Where(a => a.page.id == pageId).ToList(),
                Links = _database.Links.Where(a => a.page.id == pageId).ToList()
            };

            return Ok(webPageView);
        }

        [HttpPost]
        public async Task<ActionResult<WebPageView>> UpdatePage([FromBody] WebPageView webPageView)
        {
            if (webPageView.pageId == null || webPageView.pageId == 0)
            {
                return NotFound();
            }

            var page = await _database.Pages.FindAsync(webPageView.pageId);

            if (page == null) { return NotFound(); }

            var newArticles = webPageView.Articles.Where(a => a.id == 0);
            var newLinks = webPageView.Links.Where(a => a.id == 0);
            var newImages = webPageView.Images.Where(a => a.id == 0);
            var newFiles = webPageView.Files.Where(a => a.id == 0);

            foreach (var na in newArticles)
            {
                _database.Articles.AddAsync(na);
            }

            foreach (var nl in newLinks)
            {
                _database.Links.AddAsync(nl);
            }

            foreach (var ni in newImages)
            {
                _database.Images.AddAsync(ni);
            }
            foreach (var nf in newFiles)
            {
                _database.Files.AddAsync(nf);
            }

            await _database.SaveChangesAsync();

            WebPageView updatedPageView = new WebPageView()
            {
                pageId = webPageView.pageId,
                Articles = _database.Articles.Where(a => a.page.id == webPageView.pageId).ToList(),
                Images = _database.Images.Where(a => a.page.id == webPageView.pageId).ToList(),
                Files = _database.Files.Where(a => a.page.id == webPageView.pageId).ToList(),
                Links = _database.Links.Where(a => a.page.id == webPageView.pageId).ToList()
            };

            return Ok(updatedPageView);
        }


        private bool ApprovedCheck()
        {
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
