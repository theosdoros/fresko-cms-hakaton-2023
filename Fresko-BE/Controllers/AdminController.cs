using System.Security.Claims;
using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MSSQLApp.Data;

namespace Fresko_BE.Controllers
{
    
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AppDbContext _database;
        public AdminController(AppDbContext database) 
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(!AdminCheck()){
                return BadRequest();
            }
            return View();
        }

        [HttpGet]
        public ActionResult<List<User>> Users()
        {
            /*if(!AdminCheck()){
                return BadRequest();
            }*/
            var usersFromDatabase = _database.Users.ToList();
            return usersFromDatabase;
        }

        [HttpGet]
        public ActionResult<List<User>> UsersSearch(string searchString)
        {
            if(!AdminCheck()){
                return BadRequest();
            }
            var usersFromDatabase = _database.Users.Where(s => s.username.Contains(searchString)).ToList();
            return Ok(usersFromDatabase);
        }

        [HttpPost]
        public ActionResult<User> ApproveUser(int id){
            if(!AdminCheck()){
                return BadRequest();
            }
            var user = _database.Users.FirstOrDefault(u => u.id == id);
            if(user is null){
                return BadRequest(user);
            }
            user.approved = true;
            _database.Update(user);
            _database.SaveChanges();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> AddAdmin(int id){
            if(!AdminCheck()){
                return BadRequest();
            }
            var user = _database.Users.FirstOrDefault(u => u.id == id);
            if(user is null){
                return BadRequest(user);
            }
            user.is_admin = true;
            _database.Update(user);
            _database.SaveChanges();
            return Ok(user);            
        }

        [HttpPost]
        public ActionResult<User> DeleteUser(int id){
            if(!AdminCheck()){
                return BadRequest();
            }
            var user = _database.Users.FirstOrDefault(u => u.id == id);
            if(user is null){
                return BadRequest(user);
            }
            _database.Remove(user);
            _database.SaveChanges();
            return Ok(user);
        }

        private bool AdminCheck(){
            string isAdmin = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value;
            return isAdmin == "True";
        }

    }
}
