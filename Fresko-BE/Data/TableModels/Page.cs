using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Fresko_BE.Data.TableModels
{
    [Table("pages")]
    public class Page
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        [Required]
        public int parent_id { get; set; }

        /*[Required]
        public int user_id { get; set; }

        [Required]
        public int page_id { get; set; }*/

        [Required, StringLength(128)]
        public string page_name { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime creation_date { get; set; }
        [Required] 
        public List<AllComponents> Components { get; } = new();

        public User user { get; set; } = null!;
    }
}
