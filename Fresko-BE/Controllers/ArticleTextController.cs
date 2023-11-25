using System.Security.Claims;
using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSQLApp.Data;


namespace Fresko_BE.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArticleTextController : Controller
    {

        private readonly AppDbContext _database;
        public ArticleTextController(AppDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public string Index()
        {
            return "RADI";
        }

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] ArticleTextModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                ArticleText articleText = ComponentsService.AddComponent(model);

                await _database.Articles.AddAsync(articleText);
                await _database.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var articleTextFromDatabase = await _database.Articles.FindAsync(id);

            if (articleTextFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(articleTextFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ArticleTextModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                ArticleText newObj = ComponentsService.UpdateComponent(model); 

                _database.Articles.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Article text edited successfully.";
                return Ok(model);
            } 
            catch (Exception ex)
            {
                return BadRequest();
            }    

        }

        //GET
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            var articleTextFromDatabase = await _database.Articles.FindAsync(id);

            if (articleTextFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(articleTextFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            var obj = await _database.Articles.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Articles.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "Article text deleted successfully.";
            return Ok(obj);

        }

        private bool ApprovedCheck(){
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}