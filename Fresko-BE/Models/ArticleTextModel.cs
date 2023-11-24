using Fresko_BE.Models.Interfaces;

namespace Fresko_BE.Models
{
    public class ArticleTextModel : IComponent
    {
        public int Id { get; set; }
        public string Text { get; set; }

        private AllComponentsModel ContentType = new AllComponentsModel();
    }
}
