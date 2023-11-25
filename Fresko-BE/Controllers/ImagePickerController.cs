using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImagePickerModel model)
        {
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var imagePickerFromDatabase = await _database.Images.FindAsync(id);

            if (imagePickerFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(imagePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ImagePickerModel model)
        {
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            var imagePickerFromDatabase = await _database.Images.FindAsync(id);

            if (imagePickerFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(imagePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
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
    }
}
