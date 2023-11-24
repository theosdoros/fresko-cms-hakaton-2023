using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data.TableModels
{
    [Table("file_picker")]
    public class FilePicker
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(255), DataType(DataType.Text)]
        public string absolute_path { get; set; }
        [Required, StringLength(255), DataType(DataType.Html)]
        public string description { get; set; }


        private Content content_type = new Content();
    }
}
