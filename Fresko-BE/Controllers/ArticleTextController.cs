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