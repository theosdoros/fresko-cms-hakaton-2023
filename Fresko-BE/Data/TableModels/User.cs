using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Fresko_BE.Data.TableModels
{
    [Table("users")]
    public class User{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set;}
        [Required]
        public string Username {get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set;}
        [Required]
        public bool Approved { get; set;}
        [Required]
        public bool Is_admin { get; set;}
    }
}