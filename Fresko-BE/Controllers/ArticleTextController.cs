using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;


namespace Fresko_BE.Controllers
{
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

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create([FromBody] ArticleTextModel obj)
        {
            if (ModelState.IsValid)
            {
                var newObj = new ArticleText()
                {
                    text = obj.Text
                };

                _database.Articles.Add(newObj);
                _database.SaveChanges();
                TempData["success"] = "Article text created successfully.";
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

            var articleTextFromDatabase = _database.Articles.Find(id);

            if (articleTextFromDatabase == null)
            {
                return NotFound();
            }

            return View(articleTextFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult Edit([FromBody] ArticleTextModel obj)
        {

            if (ModelState.IsValid)
            {
                var newObj = new ArticleText()
                {
                    id = obj.Id,
                    text = obj.Text
                };


                _database.Articles.Update(newObj);
                _database.SaveChanges();
                TempData["success"] = "Article text edited successfully.";
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

            var articleTextFromDatabase = _database.Articles.Find(id);

            if (articleTextFromDatabase == null)
            {
                return NotFound();
            }

            return View(articleTextFromDatabase);
        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _database.Articles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Articles.Remove(obj);
            _database.SaveChanges();
            TempData["success"] = "Article text deleted successfully.";
            return RedirectToAction("Index");

        }
    }
}