using Fresko_BE.Models.Interfaces;

namespace Fresko_BE.Models
{
    public class LinkPickerModel : IComponent
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string NameOverwrite { get; set; }


        private AllComponentsModel ContentType = new AllComponentsModel();
    }
}
