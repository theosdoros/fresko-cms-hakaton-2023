using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Fresko_BE.Data.TableModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MSSQLApp.Data;

namespace Fresko_BE.Data.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<string> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.username.ToLower().Equals(username.ToLower()));
            if(user is null){
                return "User not found";
            }
            else if(!VerifyPasswordHash(password, user.password_hash, user.password_salt)){
                return "Wrong Password";
            }

            string response = CreateToken(user);
            return response;
        }

        public async Task<string> Register(User user, string password)
        {
            if(await UserExists(user.username)){
                return "Failed";
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.password_hash = passwordHash;
            user.password_salt = passwordSalt;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return "Success";

        }

        public async Task<bool> UserExists(string username)
        {
            if(await _dbContext.Users.AnyAsync(u => u.username.ToLower() == username.ToLower())){
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user){

            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, user.is_admin.ToString()),
                new Claim(ClaimTypes.Actor, user.approved.ToString())
            };

            var appToken = _configuration.GetSection("AppSettings:Token").Value;
            if(appToken is null){
                throw new Exception("AppSettings Token is null!");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }

}