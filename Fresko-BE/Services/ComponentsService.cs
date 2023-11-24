using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Models.Interfaces;
using MSSQLApp.Data;

namespace Fresko_BE.Services
{
    public class ComponentsService
    {
        private static AppDbContext _db;
        public ComponentsService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public void AddComponent(IComponent component)
        {
            if (component is ArticleText)
            {
                AddComponent(component);
            }
            else if (component is FilePicker)
            {
                AddComponent(component);
            }
            else if (component is ImagePicker)
            {
                AddComponent(component);
            }
            else if (component is LinkPicker)
            {
                AddComponent(component);
            }
            else
            {
                return;
            }

        }
        public void AddComponent(ArticleTextModel articleText)
        {

        }
        public void AddComponent(FilePickerModel filePicker)
        {

        }
        public void AddComponent(ImagePickerModel imagePicker)
        {

        }
        public void AddComponent(LinkPicker linkPicker)
        {

        }
    }
}
