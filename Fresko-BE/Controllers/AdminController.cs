using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
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
            return View();
        }

        [HttpGet]
        public List<User> Users()
        {
            var usersFromDatabase = _database.Users.ToList();
            return usersFromDatabase;
        }

        [HttpGet]
        public List<User> UsersSearch(string searchString)
        {
            var usersFromDatabase = _database.Users.Where(s => s.Username.Contains(searchString)).ToList();
            return usersFromDatabase;
        }
    }
}
