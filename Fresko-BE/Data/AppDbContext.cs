using Fresko.Data;
using Fresko.Data.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MSSQLApp.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }


    public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // change connection string for servername (pc name)
            // create db called 'fresko'
            // case sensitive
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        //creates many to many table with all pages and contents
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>()
                .HasMany(e => e.Content)
                .WithMany(e => e.Pages)
                .UsingEntity(
                    "page_content",
                    l => l.HasOne(typeof(Content)).WithMany().HasForeignKey("content_id").HasPrincipalKey(nameof(Content.id)),
                    r => r.HasOne(typeof(Page)).WithMany().HasForeignKey("page_id").HasPrincipalKey(nameof(Page.id)),
                    j => j.HasKey("page_id", "content_id"));

            modelBuilder.Entity<Content>().HasData(new Content { id = 1, name = "article_text" });
            modelBuilder.Entity<Content>().HasData(new Content { id = 2, name = "file_picker" });
            modelBuilder.Entity<Content>().HasData(new Content { id = 3, name = "image_picker" });
            modelBuilder.Entity<Content>().HasData(new Content { id = 4, name = "link_picker" });
        }

        //add tables
        DbSet<ArticleText> Articles { get; set; }
        DbSet<FilePicker> Files { get; set; }
        DbSet<ImagePicker> Images { get; set; }
        DbSet<LinkPicker> Links { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Content> ContentModel { get; set; }

    }
}
