using Fresko_BE.Data;
using Fresko_BE.Data.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MSSQLApp.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        // tables
        public DbSet<ArticleText> Articles { get; set; }
        public DbSet<FilePicker> Files { get; set; }
        public DbSet<ImagePicker> Images { get; set; }
        public DbSet<LinkPicker> Links { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<AllComponents> Component { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PageContent> PageContent { get; set; }


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

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //creates many to many table with all pages and contents
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);

            //modelBuilder.Entity<User>()
            //   .HasMany(e => e.pages)
            //   .WithOne(e => e.User)
            //   .HasForeignKey(e => e.Id)
            //   .IsRequired();

            //modelBuilder.Entity<Page>()
            //    .HasMany(e => e.Components)
            //    .WithMany(e => e.Pages)
            //    .UsingEntity(
            //        "page_content",
            //        l => l.HasOne(typeof(AllComponents)).WithMany().HasForeignKey("content_id").HasPrincipalKey(nameof(AllComponents.id)),
            //        r => r.HasOne(typeof(Page)).WithMany().HasForeignKey("page_id").HasPrincipalKey(nameof(Page.id)),
            //        j => j.HasKey("page_id", "content_id"));

            modelBuilder.Entity<AllComponents>().HasData(new AllComponents { id = 1, name = "article_text" });
            modelBuilder.Entity<AllComponents>().HasData(new AllComponents { id = 2, name = "file_picker" });
            modelBuilder.Entity<AllComponents>().HasData(new AllComponents { id = 3, name = "image_picker" });
            modelBuilder.Entity<AllComponents>().HasData(new AllComponents { id = 4, name = "link_picker" });
            modelBuilder.Entity<User>().HasData(new User{
                id = 1,
                username = "admin",
                email = "admin@admin.com",
                password_hash = passwordHash,
                password_salt = passwordSalt,
                approved = true,
                is_admin = true,
            });
        }


    }
}
