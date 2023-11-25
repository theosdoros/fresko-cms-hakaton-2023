using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("link_picker")]
    public class LinkPicker
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int id { get; set; }
        [Required, StringLength(255), DataType(DataType.Text)]
        public string url { get; set; }
        [Required, StringLength(64), DataType(DataType.Text)]
        public string name_overwrite { get; set; }



        private AllComponents content_type = new AllComponents();
    }
}
