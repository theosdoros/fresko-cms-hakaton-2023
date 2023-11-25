using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("article_text")]
    public class ArticleText
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int id { get; set; }
        [Required, StringLength(250), DataType(DataType.Html)]
        public string text { get; set; }

        private AllComponents content_type = new AllComponents();
    }
}
