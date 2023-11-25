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
        public async Task<IActionResult> Create()
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            return Ok();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LinkPickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                LinkPicker linkPicker = ComponentsService.AddComponent(model);

                await _database.Links.AddAsync(linkPicker);
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

            var linkPickerFromDatabase = await _database.Links.FindAsync(id);

            if (linkPickerFromDatabase == null)
            {
                return NotFound();
            }

            return Ok(linkPickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] LinkPickerModel model)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            try
            {
                LinkPicker newObj = ComponentsService.UpdateComponent(model);

                _database.Links.Update(newObj);
                await _database.SaveChangesAsync();
                TempData["success"] = "Link picker edited successfully.";
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

            var linkPickerFromDatabase = await _database.Links.FindAsync(id);

            if (linkPickerFromDatabase == null)
            {
                return BadRequest();
            }

            return Ok(linkPickerFromDatabase);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            if(!ApprovedCheck()){
                return BadRequest();
            }
            var obj = await _database.Links.FindAsync(id);
            if (obj == null)
            {
                return BadRequest();
            }

            _database.Links.Remove(obj);
            await _database.SaveChangesAsync();
            TempData["success"] = "Link picker deleted successfully.";
            return Ok(obj);
        }
        private bool ApprovedCheck(){
            string isApproved = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)!.Value;
            return isApproved == "True";
        }
    }
}
