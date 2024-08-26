using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }  // Foreign key for User
        public User User { get; set; }

        [Required]
        public int ArticleId { get; set; }  // Foreign key for Article
        public Article Article { get; set; }

        public int LikeCounter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AdminApprovalDate { get; set; }

        [Required]
        public bool AdminApproval { get; set; }


    }
}
