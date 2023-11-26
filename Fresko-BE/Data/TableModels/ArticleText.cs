using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresko_BE.Data.TableModels
{
    [Table("article_text")]
    public class ArticleText
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }
        [Required, StringLength(250), DataType(DataType.Html)]
        public string text { get; set; }
        [Required]
        public int position { get; set; }
        [Required]
        public DateTime cretion_date { get; set; }

        public Page page { get; set; } = null;

        private AllComponents content_type = new AllComponents();
    }
}
