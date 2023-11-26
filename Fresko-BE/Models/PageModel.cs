using Fresko_BE.Data.TableModels;

namespace Fresko_BE.Models
{
    public class PageModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        /*public int UserId { get; set; }

        public int PageID { get; set; }*/
        public string PageName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<AllComponents> Content { get; } = new();

        public User User { get; set; } = null!;
    }
}
