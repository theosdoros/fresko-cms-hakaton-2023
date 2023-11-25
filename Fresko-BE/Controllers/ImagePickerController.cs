using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
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
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create([FromBody] ImagePickerModel obj)
        {
            if (ModelState.IsValid)
            {
                var newObj = new ImagePicker()
                {
                    absolute_path = obj.AbsolutePath,
                    description = obj.Description
                };

                _database.Images.Add(newObj);
                _database.SaveChanges();
                TempData["success"] = "Image created successfully.";
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

            var imagePickerFromDatabase = _database.Images.Find(id);

            if (imagePickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(imagePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult Edit([FromBody] ImagePickerModel obj)
        {

            if (ModelState.IsValid)
            {
                var newObj = new ImagePicker()
                {
                    id = obj.Id,
                    absolute_path = obj.AbsolutePath,
                    description = obj.Description
                };


                _database.Images.Update(newObj);
                _database.SaveChanges();
                TempData["success"] = "Image edited successfully.";
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

            var imagePickerFromDatabase = _database.Images.Find(id);

            if (imagePickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(imagePickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _database.Images.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Images.Remove(obj);
            _database.SaveChanges();
            TempData["success"] = "Image deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
