using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data.TableModels
{
    [Table("all_components")]
    public class Content
    {
        [Required, Key]
        public int id { get; set; }
        [Required, StringLength(64)]
        public string name { get; set; }
        [Required] 
        public List<Page> Pages { get; } = new();
    }
}
