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
        public string Index()
        {
            return "RADI";
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PageModel model)
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            try
            {
                Page page = ComponentsService.AddComponent(model);

                await _database.Pages.AddAsync(page);
                await _database.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
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
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!ApprovedCheck())
            {
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            var pageFromDatabase = await _database.Pages.FindAsync(id);

            if (pageFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(pageFromDatabase);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
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

        [HttpPost]
        [Route("/{pagePublish}")]
        public async Task<IActionResult> PublishPage([FromBody] int pageId, [FromBody] WebPageView pageContent)
        {
            //pageName = HttpContext.Request.Query["name"];
            Page page = _database.Pages.Where(p => p.id == pageId).ToList().FirstOrDefault();

            if (page == null)
            {
                return BadRequest();
            }

            List<ArticleText> articles = pageContent.Articles;
            List<ImagePicker> images = pageContent.Images;
            List<FilePicker> files = pageContent.Files;
            List<LinkPicker> links = pageContent.Links;

            PageContent webPageView = new PageContent()
            {
                page_id = page.id,
                Articles = articles,
                Images = images,
                Links = links,
                Files = files
            };

            if (await _database.PageContent.FindAsync(webPageView.page_id) == null)
            {
                await _database.PageContent.AddAsync(webPageView);
                await _database.SaveChangesAsync();
            } 
            else
            {
                _database.PageContent.Update(webPageView);
                await _database.SaveChangesAsync();
            }

            return Ok(webPageView);
        }
        private bool ApprovedCheck()
        {
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
