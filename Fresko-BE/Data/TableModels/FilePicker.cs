using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("file_picker")]
    public class FilePicker
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int id { get; set; }
        [Required, StringLength(255), DataType(DataType.Text)]
        public string absolute_path { get; set; }
        [Required, StringLength(255), DataType(DataType.Html)]
        public string description { get; set; }


        private AllComponents content_type = new AllComponents();
    }
}
