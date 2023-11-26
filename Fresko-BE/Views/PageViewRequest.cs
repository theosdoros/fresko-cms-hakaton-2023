using Fresko_BE.Models;

namespace Fresko_BE.Views
{
    public class PageViewRequest
    {
        public int ParentId { get; set; }
        public string PageName { get; set; }
        public int UserId { get; set; }
    }
}
