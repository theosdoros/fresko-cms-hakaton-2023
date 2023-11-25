using Fresko_BE.Data.TableModels;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    public class PageController : Controller
    {
        private readonly AppDbContext _database;
        public PageController(AppDbContext database)
        {
            _database = database;
        }

        public string Index()
        {
            //IEnumerable<Page> objPagesList = _database.Pages;
            return "ova muda";
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Page obj)
        {
            if (ModelState.IsValid)
            {
                _database.Pages.Add(obj);
                _database.SaveChanges();
                TempData["success"] = "Page created successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET
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
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Page obj)
        {

            if (ModelState.IsValid)
            {
                _database.Pages.Update(obj);
                _database.SaveChanges();
                TempData["success"] = "Page edited successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET
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
        [ValidateAntiForgeryToken]
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
