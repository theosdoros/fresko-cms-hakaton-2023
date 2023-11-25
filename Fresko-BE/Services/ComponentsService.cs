using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Models.Interfaces;
using Microsoft.IdentityModel.Tokens;
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

        public static ArticleText AddComponent(ArticleTextModel articleText)
        {
            if (articleText.Text.IsNullOrEmpty()) return null;

            var article = new ArticleText()
            {
                text = articleText.Text
            };

            return article;
        }

        public static void AddComponent(FilePickerModel filePicker)
        {
            try
            {
                if (filePicker.AbsolutePath.IsNullOrEmpty()) return;
                var file = new FilePicker()
                {
                    absolute_path = filePicker.AbsolutePath,
                    description = filePicker.Description
                };
                _db.Files.Add(file);
            }
            catch (Exception ex)
            {

            }

        }
        public static void AddComponent(ImagePickerModel imagePicker)
        {
            try
            {
                if (imagePicker.AbsolutePath.IsNullOrEmpty()) return;

                var image = new ImagePicker()
                {
                    absolute_path = imagePicker.AbsolutePath,
                    description = imagePicker.Description
                };
                _db.Images.Add(image);
            }
            catch (Exception ex)
            {

            }
        }
        public static void AddComponent(LinkPickerModel linkPicker)
        {
            try
            {
                if (linkPicker.Url.IsNullOrEmpty()) return;

                var link = new LinkPicker()
                {
                    url = linkPicker.Url,
                    name_overwrite = linkPicker.NameOverwrite
                };
                _db.Links.Add(link);
            }
            catch (Exception ex)
            {

            }
        }

        public static void RemoveComponent(IComponent component)
        {
            if (component == null) return;

            if (component is ArticleTextModel)
            {
                RemoveComponent(component as ArticleTextModel);
            }
            else if (component is FilePickerModel)
            {
                RemoveComponent(component as FilePickerModel);
            }
            else if (component is ImagePickerModel)
            {
                RemoveComponent(component as ImagePickerModel);
            }
            else if (component is LinkPickerModel)
            {
                RemoveComponent(component as LinkPickerModel);
            }
            else
            {
                return;
            }
        }

        public static void RemoveComponent(ArticleTextModel articleText)
        {
            try
            {
                if (articleText.Text.IsNullOrEmpty()) return;

                var article = new ArticleText()
                {
                    text = articleText.Text
                };

                _db.Articles.Remove(article);
            }
            catch (Exception ex)
            {
            }
        }
        public static void RemoveComponent(FilePickerModel filePicker)
        {
            try
            {
                if (filePicker.AbsolutePath.IsNullOrEmpty()) return;
                var file = new FilePicker()
                {
                    absolute_path = filePicker.AbsolutePath,
                    description = filePicker.Description
                };
                _db.Files.Remove(file);
            }
            catch (Exception ex)
            {

            }

        }
        public static void RemoveComponent(ImagePickerModel imagePicker)
        {
            try
            {
                if (imagePicker.AbsolutePath.IsNullOrEmpty()) return;

                var image = new ImagePicker()
                {
                    absolute_path = imagePicker.AbsolutePath,
                    description = imagePicker.Description
                };
                _db.Images.Remove(image);
            }
            catch (Exception ex)
            {

            }
        }
        public static void RemoveComponent(LinkPickerModel linkPicker)
        {
            try
            {
                if (linkPicker.Url.IsNullOrEmpty()) return;

                var link = new LinkPicker()
                {
                    url = linkPicker.Url,
                    name_overwrite = linkPicker.NameOverwrite
                };
                _db.Links.Remove(link);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
