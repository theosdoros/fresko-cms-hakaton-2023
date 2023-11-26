using Fresko_BE.Models;
using Microsoft.Extensions.Hosting;
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
        [Required] [StringLength(100, MinimumLength = 3)]
        public string username {get; set;}
        [Required] [EmailAddress]
        public string email { get; set;}
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] password_salt { get; set;}
        [Required]
        public bool approved { get; set;}
        [Required]
        public bool is_admin { get; set;}

        public List<PageModel> pages { get; }
    }
}