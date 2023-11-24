using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko.Data
{
    [Table("article_text")]
    public class ArticleText
    {
        [Required, Key]
        public int Id { get; set; }
        [Required, StringLength(250), DataType(DataType.Text)]
        public string Text { get; set; }
    }
}
