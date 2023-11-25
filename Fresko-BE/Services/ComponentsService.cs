using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Models.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public static FilePicker AddComponent(FilePickerModel filePicker)
        {
            
            if (filePicker.AbsolutePath.IsNullOrEmpty()) return null;

            var file = new FilePicker()
            {
                absolute_path = filePicker.AbsolutePath,
                description = filePicker.Description
            };

            return file;

        }
        public static ImagePicker AddComponent(ImagePickerModel imagePicker)
        {
            if (imagePicker.AbsolutePath.IsNullOrEmpty()) return null;

            var image = new ImagePicker()
            {
                absolute_path = imagePicker.AbsolutePath,
                description = imagePicker.Description
            };

            return image;
        }
        public static LinkPicker AddComponent(LinkPickerModel linkPicker)
        {
            if (linkPicker.Url.IsNullOrEmpty()) return null;

            var link = new LinkPicker()
            {
                url = linkPicker.Url,
                name_overwrite = linkPicker.NameOverwrite
            };

            return link;
        }

        public static Page AddComponent(PageModel page)
        {
            if (page.PageName.IsNullOrEmpty()) return null;

            var newPage = new Page()
            {
                parent_id = page.ParentId,
                page_name = page.PageName       
            };

            return newPage;
        }

        public static ArticleText UpdateComponent(ArticleTextModel articleText)
        {
            if (articleText.Text.IsNullOrEmpty()) return null;

            var article = new ArticleText()
            {
                id = articleText.Id,
                text = articleText.Text
            };

            return article;
        }

        public static FilePicker UpdateComponent(FilePickerModel filePicker)
        {
            if (filePicker.AbsolutePath.IsNullOrEmpty()) return null;
            var file = new FilePicker()
            {
                id = filePicker.Id,
                absolute_path = filePicker.AbsolutePath,
                description = filePicker.Description
            };

            return file;

        }

        public static ImagePicker UpdateComponent(ImagePickerModel imagePicker)
        {
            if (imagePicker.AbsolutePath.IsNullOrEmpty()) return null;

            var image = new ImagePicker()
            {
                id = imagePicker.Id,
                absolute_path = imagePicker.AbsolutePath,
                description = imagePicker.Description
            };

            return image;
        }

        public static LinkPicker UpdateComponent(LinkPickerModel linkPicker)
        {
            if (linkPicker.Url.IsNullOrEmpty()) return null;

            var link = new LinkPicker()
            {
                id = linkPicker.Id,
                url = linkPicker.Url,
                name_overwrite = linkPicker.NameOverwrite
            };

            return link;
        }

        public static Page UpdateComponent(PageModel page)
        {
            if (page.PageName.IsNullOrEmpty()) return null;

            var newPage = new Page()
            {
                id = page.Id,
                parent_id = page.ParentId,
                page_name = page.PageName
            };

            return newPage;
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
            }
            catch (Exception ex)
            {

            }
        }

        public static void RemoveComponent(PageModel page)
        {
            try
            {
                if (page.PageName.IsNullOrEmpty()) return;

                var link = new Page()
                {
                    page_name = page.PageName,
                    parent_id = page.ParentId
                };
            }
            catch (Exception ex)
            {

            }
        }
    }
}
