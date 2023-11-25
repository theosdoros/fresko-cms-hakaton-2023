
using Fresko_BE.Data.TableModels;

namespace Fresko_BE.Data.Auth
{
    public interface IAuthRepository{

        Task<string> Register(User user, string password);
        Task<string> Login(string username, string password);

        Task<bool> UserExists(string username);
    }

}