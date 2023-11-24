using Fresko_BE.Models.Interfaces;

namespace Fresko_BE.Models
{
    public class FilePickerModel : IComponent
    {
        public int Id { get; set; }
        public string AbsolutePath { get; set; }
        public string Description { get; set; }


        private AllComponentsModel ContentType = new AllComponentsModel();
    }
}
