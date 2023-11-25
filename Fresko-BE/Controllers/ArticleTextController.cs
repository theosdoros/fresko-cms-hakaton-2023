﻿using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] ArticleTextModel model)
        {
            try
            {
                ArticleText articleText = ComponentsService.AddComponent(model);

                await _database.Articles.AddAsync(articleText);
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

            var articleTextFromDatabase = await _database.Articles.FindAsync(id);

            if (articleTextFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(articleTextFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ArticleTextModel model)
        {
            try
            {
                ArticleText newObj = ComponentsService.UpdateComponent(model); 

                _database.Articles.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Article text edited successfully.";
                return Ok(model);
            } 
            catch (Exception ex)
            {
                return BadRequest();
            }    

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