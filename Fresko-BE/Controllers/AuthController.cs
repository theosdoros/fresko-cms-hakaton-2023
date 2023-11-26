using Fresko_BE.Data.Auth;
using Fresko_BE.Data.TableModels;
using Fresko_BE.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Fresko_BE.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register(UserRegisterDto request){
            var response = await _authRepo.Register(
                new User {username = request.Username, email = request.Email, approved = false}, request.Password
            );
            if(response == "Failed" ){
                return Ok(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(UserLoginDto request){
            var response = await _authRepo.Login(request.Username, request.Password);
            if(response == "User not found" || response == "Wrong Password" ){
                return Ok(response);
            }
            return Ok(response);
        }        

    }
}