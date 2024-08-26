using DataLayout.Model;
using Microsoft.AspNetCore.Identity;
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


            // Comment ve Article arasındaki ilişki (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany(a => a.Comments)  // Article sınıfında Comments koleksiyonunu tanımlamalısınız
                .HasForeignKey(c => c.ArticleId)
                 .OnDelete(DeleteBehavior.Restrict);

            // Comment ve User arasındaki ilişkiyi tanımla
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = "1", Name = "Admin", NormalizedName = "ADMIN", RoleCounter = 1, RoleApproval = true, RoleApprovalDate = DateTime.Now },
                new Role { Id = "2", Name = "Author", NormalizedName = "AUTHOR", RoleCounter = 2, RoleApproval = true, RoleApprovalDate = DateTime.Now },
                new Role { Id = "3", Name = "User", NormalizedName = "USER", RoleCounter = 2, RoleApproval = true, RoleApprovalDate = DateTime.Now }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, Name = "Teknoloji" },
                new Tag { ID = 2, Name = "Saglık" },
                new Tag { ID = 3, Name = "Bilim" }
            );

            modelBuilder.Entity<ArticleTag>().HasData(
                new ArticleTag { ArticleId = 1, TagId = 1 },
                new ArticleTag { ArticleId = 2, TagId = 3 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Teknoloji" },
                new Category { ID = 2, Name = "Sağlık" },
                new Category { ID = 3, Name = "Bilim" }
            );

            modelBuilder.Entity<userRole>().HasData(
                new userRole { Id = "1", FirstName = "John", LastName = "Doe", UserName = "johndoe", Email = "johndoe@example.com", Phone = "1234567890", ProfileUpdateDate = DateTime.Now },
                new userRole { Id = "2", FirstName = "Jane", LastName = "Smith", UserName = "janesmith", Email = "janesmith@example.com", Phone = "0987654321", ProfileUpdateDate = DateTime.Now }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article { ID = 1,Title ="text",Text="deneme 1 2 3 .....", SingularViewedCounter = 10, PluralViewedCounter = 50, AuthorId = "3", CategoryId = 1, LikeCounter = 10, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, EditionDate = DateTime.Now, AdminApproval = true },
                new Article { ID = 2, Title = "Article 2 ", Text = "deneme 1 2 3 .....", SingularViewedCounter = 20, PluralViewedCounter = 150, AuthorId = "4", CategoryId = 3, LikeCounter = 20, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, EditionDate = DateTime.Now, AdminApproval = true }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { ID = 1, UserId = "1",Text="gayet başarılı", ArticleId = 1, LikeCounter = 5, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, AdminApprovalDate = DateTime.Now, AdminApproval = true },
                new Comment { ID = 2, UserId = "2",Text="güzel yazı elinize sağlık", ArticleId = 2, LikeCounter = 10, CreateDate = DateTime.Now, UpdateDate = DateTime.Now, AdminApprovalDate = DateTime.Now, AdminApproval = true }
            );

            modelBuilder.Entity<AuthorRole>().HasData(
                new AuthorRole { Id = "3", FirstName = "Ayse", LastName = "Yılmaz", UserName = "ayseyilmaz", Email = "ayse@example.com", Phone = "1234567890", ProfileUpdateDate = DateTime.Now },
                new AuthorRole { Id = "4", FirstName = "Mehmet", LastName = "Er", UserName = "mehmeter", Email = "mehmeter@example.com", Phone = "0987654321", ProfileUpdateDate = DateTime.Now }
            );

            modelBuilder.Entity<AuthorCategory>().HasData(
                new AuthorCategory { AuthorRoleId = "3", CategoryId = 1 },
                new AuthorCategory { AuthorRoleId = "4", CategoryId = 3 }
            );




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
