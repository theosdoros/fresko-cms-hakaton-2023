using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("all_components")]
    public class AllComponents
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        [Required, StringLength(64)]
        public string name { get; set; }
        [Required] 
        public List<Page> Pages { get; } = new();
    }
}
