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
        public string username {get; set;}
        [Required]
        public string email { get; set;}
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] password_salt { get; set;}
        [Required]
        public bool approved { get; set;}
        [Required]
        public bool is_admin { get; set;}

        public List<Page> pages { get; set; }
    }
}