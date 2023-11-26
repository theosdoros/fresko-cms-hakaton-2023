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
    public class ImageController : Controller
    {

        private readonly AppDbContext _database;
        public ImageController(AppDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public string Index()
        {
            return "RADI";
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImagePickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                ImagePicker imagePicker = ComponentsService.AddComponent(model);

                await _database.Images.AddAsync(imagePicker);
                await _database.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ImagePickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                ImagePicker newObj = ComponentsService.UpdateComponent(model);

                _database.Images.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Image picker edited successfully.";
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
            var obj = await _database.Images.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Images.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "Image picker deleted successfully.";
            return Ok(obj);
        }

        private bool ApprovedCheck(){
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
