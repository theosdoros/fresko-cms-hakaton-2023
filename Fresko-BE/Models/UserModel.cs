namespace Fresko_BE.Models
{
    public class UserModel{

        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set;} = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set;}
        public bool Approved { get; set;} = false;

    }


}