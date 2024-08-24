using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Article
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        public int singularViewedCounter { get; set; }

        public int pluralViewedCounter { get; set; }

        [Required]
        public Category category { get; set; }

        [Required]
        public AuthorRole author {  get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; } // Many-to-Many ilişki için


        public ICollection<Comment> comments { get; set; }

        public int likeCounter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime createDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime updateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime editionDate { get; set; }

        [Required]
        public Boolean adminApproval { get; set; }

        public ICollection<Image> images { get; set; }

    }
}
