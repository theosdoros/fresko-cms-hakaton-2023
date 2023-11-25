using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
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

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create([FromBody] PageModel obj)
        {
            if (ModelState.IsValid)
            {
                var newObj = new Page()
                {
                    parent_id = obj.ParentId,
                    page_name = obj.PageName,
                    creation_date = obj.CreationDate
                };

                _database.Pages.Add(newObj);
                _database.SaveChanges();
                TempData["success"] = "Page created successfully.";
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

            var pageFromDatabase = _database.Pages.Find(id);

            if (pageFromDatabase == null)
            {
                return NotFound();
            }

            return View(pageFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult Edit([FromBody] PageModel obj)
        {

            if (ModelState.IsValid)
            {
                var newObj = new Page()
                {
                    id = obj.Id,
                    parent_id = obj.ParentId,
                    page_name = obj.PageName,
                    creation_date = obj.CreationDate
                };


                _database.Pages.Update(newObj);
                _database.SaveChanges();
                TempData["success"] = "Page edited successfully.";
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

            var pageFromDatabase = _database.Pages.Find(id);

            if (pageFromDatabase == null)
            {
                return NotFound();
            }

            return View(pageFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _database.Pages.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Pages.Remove(obj);
            _database.SaveChanges();
            TempData["success"] = "Game deleted successfully.";
            return RedirectToAction("Index");

        }
    }
}
