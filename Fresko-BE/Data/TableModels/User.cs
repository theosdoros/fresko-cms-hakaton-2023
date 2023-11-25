using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("users")]
    public class User{
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int id { get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set;}
    }
}