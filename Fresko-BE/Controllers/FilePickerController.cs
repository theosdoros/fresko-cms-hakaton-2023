using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FilePickerModel model)
        {
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var filePickerFromDatabase = await _database.Files.FindAsync(id);

            if (filePickerFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(filePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] FilePickerModel model)
        {
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

        //GET
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            var filePickerFromDatabase = await _database.Files.FindAsync(id);

            if (filePickerFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(filePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
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
    }
}
