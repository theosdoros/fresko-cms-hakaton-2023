using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
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
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create([FromBody] FilePickerModel obj)
        {
            if (ModelState.IsValid)
            {
                var newObj = new FilePicker()
                {
                    absolute_path = obj.AbsolutePath,
                    description = obj.Description
                };

                _database.Files.Add(newObj);
                _database.SaveChanges();
                TempData["success"] = "File picker created successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var filePickerFromDatabase = _database.Files.Find(id);

            if (filePickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(filePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult Edit([FromBody] FilePickerModel obj)
        {

            if (ModelState.IsValid)
            {
                var newObj = new FilePicker()
                {
                    id = obj.Id,
                    absolute_path = obj.AbsolutePath,
                    description = obj.Description
                };


                _database.Files.Update(newObj);
                _database.SaveChanges();
                TempData["success"] = "File picker edited successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var filePickerFromDatabase = _database.Files.Find(id);

            if (filePickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(filePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _database.Files.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Files.Remove(obj);
            _database.SaveChanges();
            TempData["success"] = "File picker deleted successfully.";
            return RedirectToAction("Index");

        }
    }
}
