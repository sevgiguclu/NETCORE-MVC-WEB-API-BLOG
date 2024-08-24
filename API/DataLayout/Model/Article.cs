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
        public int ID { get; set; }

        public int SingularViewedCounter { get; set; }
        public int PluralViewedCounter { get; set; }

        [Required]
        public string AuthorId { get; set; }  // Foreign key for Author (string)

        public AuthorRole Author { get; set; }  

        [Required]
        public int CategoryId { get; set; }  // Foreign key for Category
        public Category Category { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public int LikeCounter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EditionDate { get; set; }

        [Required]
        public bool AdminApproval { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}
