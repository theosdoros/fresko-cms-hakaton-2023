using Fresko_BE.Models.Interfaces;

namespace Fresko_BE.Models
{
    public class ImagePickerModel : IComponent
    {
        public int Id { get; set; }
        public string AbsolutePath { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public DateTime CreationDate { get; set; }

        private AllComponentsModel ContentType = new AllComponentsModel();
    }
}