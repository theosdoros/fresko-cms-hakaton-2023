using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("page_content")]
    public class PageContent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        [Required]
        public int page_id { get; set; }
        [Required]
        public int component_id { get; set; }
        [Required]
        public string component_alias { get; set; }
        public List<ArticleText> Articles { get; set; }
        public List<ImagePicker> Images { get; set; }
        public List<FilePicker> Files { get; set; }
        public List<LinkPicker> Links { get; set; }

    }
}
