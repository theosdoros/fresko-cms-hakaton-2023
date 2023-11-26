using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Fresko_BE.Views;

namespace Fresko_BE.Services
{
    public class PageService
    {
        public static Page AddPage(PageViewRequest page)
        {
            if (string.IsNullOrEmpty(page.PageName)) return null;
            Page pageModel = new Page()
            {
                parent_id = page.ParentId,
                creation_date = DateTime.Now,
                page_name = page.PageName,
                user_id = page.UserId
            };
            return pageModel;
        }
    }
}
