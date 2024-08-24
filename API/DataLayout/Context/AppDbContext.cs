using DataLayout.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Article ve Author arasındaki ilişki
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);

            // Article ve Category arasındaki ilişki
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId);

            // Article ve Comment arasındaki ilişki
            modelBuilder.Entity<Article>()
                .HasMany(a => a.Comments)  // Article.Comments koleksiyonu
                .WithOne(c => c.Article)  // Comment.Article navigasyon özelliği
                .HasForeignKey(c => c.ArticleId);  // Comment.ArticleId yabancı anahtar olarak kullanılır

            // Article ve Tag arasındaki Many-to-Many ilişki
            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });  // Composite key

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTags)
                .HasForeignKey(at => at.ArticleId);

            modelBuilder.Entity<ArticleTag>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId);

            // AuthorRole ve Article arasındaki ilişki (One-to-Many)
            modelBuilder.Entity<AuthorRole>()
                .HasMany(ar => ar.Articles)  // AuthorRole.Articles koleksiyonu
                .WithOne(a => a.Author)  // Article.Author navigasyon özelliği
                .HasForeignKey(a => a.AuthorId);  // Article.AuthorId yabancı anahtar olarak kullanılır

            // AuthorRole ve Category arasındaki Many-to-Many ilişki
            modelBuilder.Entity<AuthorCategory>()
                .HasKey(ac => new { ac.AuthorRoleId, ac.CategoryId });

            modelBuilder.Entity<AuthorCategory>()
                .HasOne(ac => ac.AuthorRole)
                .WithMany(ar => ar.AuthorCategories)
                .HasForeignKey(ac => ac.AuthorRoleId);

            modelBuilder.Entity<AuthorCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.AuthorCategories)
                .HasForeignKey(ac => ac.CategoryId);

            modelBuilder.Entity<Comment>()
                .HasOne(u=>u.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c=>c.UserId);

            // Comment ve Article arasındaki ilişki (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)  // Article sınıfında Comments koleksiyonunu tanımlamalısınız
                .HasForeignKey(c => c.ArticleId);

            // Article ve Image arasındaki ilişki (One-to-Many)
            modelBuilder.Entity<Image>()
                .HasOne(a => a.Article)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ArticleId);

            // Notification ve User arasındaki ilişki (Many-to-One)
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)  // User sınıfındaki Notifications koleksiyonu
                .HasForeignKey(n => n.UserId);


            // userRole ve Category arasındaki ilişkiyi tanımla
            modelBuilder.Entity<userRole>()
                .HasMany(ur => ur.ArticleCategoryList)
                .WithMany(c => c.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCategory",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    j => j.HasOne<userRole>().WithMany().HasForeignKey("UserId"));

            // userRole ve Comment arasındaki ilişkiyi tanımla
            modelBuilder.Entity<userRole>()
                .HasMany(ur => ur.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

        }


        // Identity tabloları için
        public DbSet<User> Users { get; set; }

        // Diğer tablolar için
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<AuthorRole> AuthorRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<userRole> UserRoles { get; set; }
    }
}
