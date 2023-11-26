using Fresko_BE.Data.TableModels;
using System.Diagnostics.Eventing.Reader;

namespace Fresko_BE.Models
{
    public class UserModel{

        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set;} = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set;}
        public bool Approved { get; set;} = false;

        public bool Is_admin { get; set;} = false;

        public List<PageModel> Pages { get; set; } = new List<PageModel>();

    }


}