namespace Fresko_BE.Models
{
    public class AllComponentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PageModel> Pages { get; } = new();
    }
}
