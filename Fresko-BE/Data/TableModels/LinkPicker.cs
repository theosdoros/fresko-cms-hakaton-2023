using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data.TableModels
{
    [Table("link_picker")]
    public class LinkPicker
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(255), DataType(DataType.Text)]
        public string url { get; set; }
        [Required, StringLength(64), DataType(DataType.Text)]
        public string name_overwrite { get; set; }



        private Content content_type = new Content();
    }
}
