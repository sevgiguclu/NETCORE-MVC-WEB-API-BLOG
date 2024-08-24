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
        public int ID {  get; set; }

        [Required]
        [ForeignKey("userID")]
        public int userId { get; set; }

        [Required]
        public userRole user { get; set; }

        [Required]
        [ForeignKey("articleId")]
        public int articleId { get; set; }

        [Required]
        public Article article { get; set; }

        public int likeCounter { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime createDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime updateDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime adminApprovalDate { get; set; }

        [Required]
        public Boolean adminApproval {  get; set; }




    }
}
