using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data.TableModels
{
    [Table("article_text")]
    public class ArticleText
    {
        [Required, Key]
        public int id { get; set; }
        [Required, StringLength(250), DataType(DataType.Html)]
        public string text { get; set; }

        private Content content_type = new Content();
    }
}
