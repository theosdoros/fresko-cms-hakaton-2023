using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LinkPickerController : Controller
    {

        private readonly AppDbContext _database;
        public LinkPickerController(AppDbContext database)
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
        public IActionResult Create([FromBody] LinkPickerModel obj)
        {
            if (ModelState.IsValid)
            {
                var newObj = new LinkPicker()
                {
                    url = obj.Url,
                    name_overwrite = obj.NameOverwrite

                };

                _database.Links.Add(newObj);
                _database.SaveChanges();
                TempData["success"] = "Link picker created successfully.";
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

            var linkPickerFromDatabase = _database.Pages.Find(id);

            if (linkPickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(linkPickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult Edit([FromBody] LinkPickerModel obj)
        {

            if (ModelState.IsValid)
            {
                var newObj = new LinkPicker()
                {
                    id = obj.Id,
                    url = obj.Url,
                    name_overwrite = obj.NameOverwrite
                };


                _database.Links.Update(newObj);
                _database.SaveChanges();
                TempData["success"] = "Link picker edited successfully.";
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

            var linkPickerFromDatabase = _database.Pages.Find(id);

            if (linkPickerFromDatabase == null)
            {
                return NotFound();
            }

            return View(linkPickerFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _database.Links.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Links.Remove(obj);
            _database.SaveChanges();
            TempData["success"] = "Link picker deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
