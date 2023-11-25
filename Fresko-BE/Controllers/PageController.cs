﻿using System.Security.Claims;
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
        public async Task<IActionResult> Create()
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            return Ok();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PageModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                Page page = ComponentsService.AddComponent(model);

                await _database.Pages.AddAsync(page);
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
            if(!ApprovedCheck()){
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pageFromDatabase = await _database.Pages.FindAsync(id);

            if (pageFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(pageFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] PageModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                var newObj = ComponentsService.UpdateComponent(model);

                _database.Pages.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Page edited successfully.";
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
            if(!ApprovedCheck()){
                return BadRequest();
            }
            if (id == null || id == 0)
            {
                return BadRequest();
            }

            var pageFromDatabase = await _database.Pages.FindAsync(id);

            if (pageFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(pageFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            var obj = await _database.Pages.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Pages.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "Page deleted successfully.";
            return Ok(obj);
        }
        private bool ApprovedCheck(){
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
