using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data.TableModels
{
    [Table("pages")]
    public class Page
    {
        [Required, Key]
        public int id { get; set; }
        [Required]
        public int parent_id { get; set; }
        [Required, StringLength(128)]
        public string page_name { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime creation_date { get; set; }
        [Required] 
        public List<Content> Content { get; } = new();
    }
}
