using System.Security.Claims;
using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class FilePickerController : Controller
    {

        private readonly AppDbContext _database;
        public FilePickerController(AppDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public string Index()
        {
            return "RADI";
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FilePickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                FilePicker filePicker = ComponentsService.AddComponent(model);

                await _database.Files.AddAsync(filePicker);
                await _database.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] FilePickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                FilePicker newObj = ComponentsService.UpdateComponent(model);

                _database.Files.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "File picker edited successfully.";
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            var obj = await _database.Files.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Files.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "File picker deleted successfully.";
            return Ok(obj);
        }

        private bool ApprovedCheck(){
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
