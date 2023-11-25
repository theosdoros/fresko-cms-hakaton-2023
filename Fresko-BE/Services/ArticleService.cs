using Fresko_BE.Data.TableModels;
using Fresko_BE.Models;
using Microsoft.IdentityModel.Tokens;
using MSSQLApp.Data;

namespace Fresko_BE.Services
{
    public class ArticleService
    {
        private static AppDbContext _db;
        public ArticleService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public static List<ArticleTextModel> GetAllArticles()
        {
            var tableArticles = _db.Articles.ToList();
            List<ArticleTextModel> articles = new List<ArticleTextModel>();
            foreach (var a in tableArticles)
            {
                articles.Add(new ArticleTextModel()
                {
                    Id = a.id,
                    Text = a.text
                });
            }
            return articles;
        }

        public static ArticleTextModel GetArticle(int id)
        {
            if (id < 0) return null;
            var tableArticle = _db.Articles.Find(id);
            var article = new ArticleTextModel()
            {
                Id = tableArticle.id,
                Text = tableArticle.text
            };
            return article;
        }

        public static ArticleTextModel AddArticle(ArticleTextModel article)
        {
            if (article.Id < 0 && article.Text.IsNullOrEmpty()) return null;

            var articleTable = new ArticleText()
            {
                text = article.Text
            };
            _db.Articles.Add(articleTable);
            _db.SaveChanges();
            return article;
        }

        public static void DeleteArticle(int id)
        {
            if (id < 0) return;
            ArticleTextModel article = ArticleService.GetArticle(id);

            var articleTable = new ArticleText()
            {
                id = article.Id,
                text = article.Text
            };
            _db.Articles.Attach(articleTable);
            _db.Articles.Remove(articleTable);
            _db.SaveChanges();
        }

        public static ArticleTextModel UpdateArticle(int id, string text)
        {
            if (id < 0 && text.IsNullOrEmpty()) return null;
            ArticleText articleTable = _db.Articles.Find(id);
            return null; //nastavljam sutra umiremise
        }
    }
}
