using Fresko_BE.Data.TableModels;

namespace Fresko_BE.Views
{
    public class WebPageView
    {
        public int pageId { get; set; }
        public List<ArticleText> Articles { get; set; }
        public List<ImagePicker> Images { get; set; }
        public List<FilePicker> Files { get; set; }
        public List<LinkPicker> Links { get; set; }
    }
}
